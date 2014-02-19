<?php
include ('../includes/library.php');

$checkSession = "true";
require ('fpdf.php');

require ('pdf/rotation.php');

define('FPDF_FONTPATH', 'pdf/font/');

$id_project = $_REQUEST['id'];

function pega_status($id) {
	//Inicio Planejado 1
	$tmpqfas1 = " WHERE fas.id_projeto = '" . $id . "' and fas.tipo_fase = '1'";
	$requestfase1 = new request();
	$requestfase1->openFases($tmpqfas1);

	//Inicio Implantação 7
	$tmpimpfas2 = " WHERE fas.id_projeto = '" . $id . "' and fas.tipo_fase = '7'";
	$requestimp2 = new request();
	$requestimp2->openFases($tmpimpfas2);
	//fim Implantação 7
	$dat_pla_1 = $requestfase1->fas_dat_ini_plan[0];
	$dat_pla_2 = $requestimp2->fas_dat_fim_plan[0];

	$dat_pla_3 = $requestfase1->fas_dat_ini_real[0];
	$dat_pla_4 = $requestimp2->fas_dat_fim_real[0];

	$statuss = fase_status($dat_pla_1, $dat_pla_2, $dat_pla_3, $dat_pla_4);

	return $statuss;

}

//Pega os sistemas 
function sistema($id) {
	//$tmpquerys = "WHERE sis.id = ".$id."";
	//$tmpquerys = "AND SG.NU_SEQ_APLICACAO = ".$id."";
	$tmpquerys = " ";
	$listSistem = new request();
	//$listSistem->openSistema($tmpquerys);
	$listSistem->openSisunio($tmpquerys);
	$comp = count($listSistem->sis_id);
	for ($i = 0; $i < $comp; $i++) {

		if ($listSistem->sis_id[$i] == $id) {
			$nome = $listSistem->sis_nome[$i];
		}
	}

	if ($comp > 0) {
		//$nome = $listSistem->sis_nome[0];
	} else {
		$nome = "----";
	}

	return $nome;

}

$tmpquery = "WHERE pro.id = '$id_project'";

$projectDetail = new request();
$projectDetail->openProjects($tmpquery);
$comptProjectDetail = count($projectDetail->pro_id);
//echo $comptProjectDetail;
switch ($projectDetail->pro_t_demada[0]) {
	case 0 :
		$tipo_demanda = "Novo Sistema";
		break;
	case 1 :
		$tipo_demanda = "Corretiva";
		break;
	case 2 :
		$tipo_demanda = "Evolutiva";
		break;
}

$ll = $projectDetail->pro_sistema[0];
$idStatus = $projectDetail->pro_status[0];
$idPriority = $projectDetail->pro_priority[0];

if (!$ll == "") {

	$system = sistema($ll);

} else {

	$system = sistema('0');

}
$sel_member = new request();
$tmquery_member = "AND SU.nu_seq_usuario =" . fixInt($projectDetail->pro_owner[0]);
$sel_member->openMembers($tmquery_member);
$nome_gestor = $sel_member->mem_name[0];
//----------$projectDetail->pro_owner[0];------------------
//-----------inicio ger rel------------------
$sel_grel = new request();
$tmquery_rel = "AND SU.nu_seq_usuario =" . fixInt($projectDetail->pro_mem_idpla[0]);
$sel_grel->openMembers($tmquery_rel);

if ($sel_grel->mem_name[0] != "") {
	$nome_g_rel = $sel_grel->mem_name[0];
	$tel_g_rel = " Telefone: " . $sel_grel->mem_phone_work[0];
} else {
	$nome_g_rel = "Em Definição...";
	$tel_g_rel = "";
}
//-----------fim ger rel---------------------

//-----------inicio ger pro------------------
$sel_gepro = new request();
$tmquery_gpro = "AND SU.nu_seq_usuario =" . fixInt($projectDetail->pro_mem_idgpro[0]);
//$sel_gepro->openMembers($tmquery_gpro);
$sel_gepro->openMembers($tmquery_gpro);

if ($sel_gepro->mem_name[0] != "") {
	$nome_g_pro = $sel_gepro->mem_name[0];
} else {
	$nome_g_pro = "Em Definição...";
}
//-----------fim ger pro---------------------

//-----------inicio corra------------------
$sel_corra = new request();
$tmquery_corra = "AND mem.id =" . fixInt($projectDetail->pro_mem_corra[0]);
$sel_corra->openMembers($tmquery_corra);
if ($sel_corra->mem_name[0] != "") {
	$nome_corra = $nomecorra[0];
} else {
	$nome_corra = "Em Definição...";
}
//-----------fim corra---------------------

$sel_analita = new request();
$tmquery_analita = " AND SU.nu_seq_usuario =" . fixInt($projectDetail->pro_idcordena[0]);
$sel_analita->openMembers($tmquery_analita);
$contAnalita = count($sel_analita->mem_id);
if ($sel_analita->mem_name[0] != "") {
	$nome_analita = $sel_analita->mem_name[0];
} else {
	$nome_analita = "Em Definição...";
}
//-----------fim Analista--------------------- 

//-----------unidade admin--------------------
$sql = "select s_unidade_org.sg_unidade_org NAME from sistru_adm.s_unidade_org, sgd_fnde.projects
     where projects.organization = s_unidade_org.nu_seq_interno_uorg and projects.ID = $id_project";
$result = OCIParse($con, $sql);
OCIExecute($result);
while (OCIFetch($result)) {
	$unidade = OCIResult($result, "NAME");
}
//-----------fim unidade admin----------------

//-----------inicio Analista---------------------

$sqlA = "
	 SELECT u.nu_seq_usuario ID, c.no_cadastro NAME, MEM.PROFIL,
       uo.sg_unidade_org lotacao, uo.nu_seq_interno_uorg ID_UNIDADE
       FROM  segweb_fnde.s_usuario u
		, segweb_fnde.s_usuario_interno ui
		, rh_fnde.s_cadastro c
		, rh_fnde.s_cadastro_tipo ct
		, rh_fnde.s_cadastro_lotacao cl
		, sistru_adm.s_unidade_org uo
		, sgd_fnde.members MEM
		, SGD_FNDE.PROJECTS PROJ
		where 
		u.nu_seq_usuario = ui.nu_seq_usuario
		and ui.nu_seq_cadastro = c.nu_seq_cadastro
		and c.nu_seq_cadastro = ct.nu_seq_cadastro
		and ct.dt_saida_orgao is null
		and ct.co_tipo_cadastro in (1,2,3)
		and ct.nu_seq_cadastro_tipo = cl.nu_seq_cadastro_tipo
		and cl.dt_saida_lotacao is null
		and cl.nu_seq_interno_uorg = uo.nu_seq_interno_uorg
		AND PROJECTS.ID_RELACIONAMENTO = MEMBERS.ID 
		AND PROJECTS.ID = $id_project ORDER BY c.no_cadastro";
		
$result2 = connectSql($sqlA);
OCIExecute($result2);
$row2 = OCIFetchStatement($result2, $res2);

if ($row2 > 0) {
	OCIExecute($result2);
	while (OCIFetch($result2)) {
		$AnalistRel = OCIResult($result2, "NAME");
	}
} else {
	$AnalistRel = "Em Definição...";
}

$sel_analista = new request();
$tmquery_analista = " AND SU.nu_seq_usuario = " . fixInt($projectDetail->pro_men_analista[0]);
$sel_analista->openMembers($tmquery_analista);
$contAnalista = count($sel_analista->mem_id);
if ($sel_analista->mem_name[0] != "") {
	$nome_analista = $sel_analista->mem_name[0];
} else {
	$nome_analista = "Em Definição...";
}
//-----------fim Analista--------------------- 

//-----------------Data da Fase da Demanda----------------

$sqlDFA = "SELECT DATA_FASE FROM SGD_FNDE.FASES WHERE ID_PROJETO = '" . $projectDetail->pro_id[0] . "' AND DATA_FASE IS NOT NULL";
$resultDFA = OCIParse($con, $sqlDFA);
OCIExecute($resultDFA);
$rowDFA = OCIFetchStatement($resultDFA, $resDFA);
OCIExecute($resultDFA);
while (OCIFetch($resultDFA)) {
	$DataFaseDemanda = OCIResult($resultDFA, "DATA_FASE");
}

//----------------Fim Data da Fase da Demanda-------------
$statuss = pega_status($projectDetail->pro_id[0]);

class PDF extends PDF_Rotate {
	//Page header
	function Header() {
		//Marca D agua no Relatorio
		$this->SetFont('Arial', 'B', 64);
		$this->SetTextColor(255, 192, 203);
		$this->RotatedText(50, 150, '', 24);
	}

	function RotatedText($x, $y, $txt, $angle) {
		//Text rotated around its origin
		$this->Rotate($angle, $x, $y);
		$this->Text($x, $y, $txt);
		$this->Rotate(0);
	}
	function Footer() {
		$this->SetLineWidth(0.5);
		$this->Line(296, 196, 1, 196);
		$this->SetY(-15);
		$this->line(10, $this->GetY() - 2, $this->GetX(), $this->GetY() - 2);
		$this->SetX(15);
		$this->SetFont('Arial', '', 7);
		$data = strftime("%d/%m/%Y");
		$this->SetTextColor(0, 0, 0);
		$this->Cell(200, 10, "Data de Impressão : " . $data, 0, 0, 'L');
		$this->SetTextColor(0, 0, 0);
		$this->SetFont('Arial', '', 7);
		$this->Cell(0, 10, 'Página  ' . $this->PageNo() . ' / {nb} ', 0, 0, 'R');
	}
}
//Instanciation of inherited class
$pdf = new PDF('P');
$pdf->Open();
$pdf->AliasNbPages();
$pdf->AddPage();
$pdf->SetFont('Times', '', 12);
for ($i = 1; $i <= 40; $i++)
	$pdf->AliasNbPages();

$pdf->SetXY(0, 20);
$pdf->Image('images/fndelogo.jpg', 9, 3, 30, 15);

//$pdf->SetXY(30,20);

$pdf->SetXY(40, 5);
$pdf->SetFillColor(255); // Cor de Preencimento da Celula
//
$pdf->SetTextColor(); //Cor da fonte 
$pdf->SetDrawColor(0, 0, 0);
$pdf->SetLineWidth(.3);
$pdf->SetFont('helvetica', 'B', 11);
$pdf->Cell(220, 4, "Ministério da Educação", 0, 2, 'L', 1);
$pdf->Cell(220, 4, "Fundo Nacional de Desenvolvimento da Educação", 0, 2, 'L', 1);
$pdf->Cell(220, 4, "SGD - Sistema de Gestão de Demandas", 0, 2, 'L', 1);
$pdf->SetXY(0, 20);
$pdf->Cell(-100, -4, "          _______________________________________________________________________________________ ", 0, 2, 'L', 0);

$pdf->SetXY(11, 20);
$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
$pdf->SetFont('helvetica', 'B', 11);
$pdf->Cell(180, 17, "Identificação da Demanda: " . $projectDetail->pro_name[0], 0, 2, 'L', 1);
$pdf->SetX(0);
$pdf->Cell(50, -12, "          _______________________________________________________________________________________ ", 0, 2, 'L', 0);
//$pdf->Cell(31,18,"",0,1,'C',0);
$pdf->SetDrawColor(0, 0, 0); // color of the cell borders 
$pdf->SetLineWidth(.3); // width of the cell borders 
$pdf->SetXY(24, 35); // Will place the table at X coordinate 100 

// Colors and Line Widths for Header Cells 
$pdf->SetFillColor(255); // Cor de Fundo das Celulas 
$pdf->SetTextColor(40, 58, 101); // text color inside cells 
$pdf->SetDrawColor(255, 255, 255); // color of the cell borders 
$pdf->SetLineWidth(.3); // width of the cell borders 
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 

// Largura 50, Altura 7, Texto, Com borda, Proximo na mesma Linha, Texto Centralizado, filled cell

//Cor e fonte para linha de dados
$pdf->SetFillColor(234, 234, 235);
$pdf->SetTextColor(0);
$pdf->SetFont('');

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(50, 5, "Nº da Demanda: ", 1, 0, 'L', 0);
$pdf->SetX(34);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $projectDetail->pro_id[0], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Título da Demanda:", 1, 0, 'L', 0);
$pdf->SetX(38);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $projectDetail->pro_name[0], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Status:", 1, 0, 'L', 0);
$pdf->SetX(22);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $status[$idStatus], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Tipo:", 1, 0, 'L', 0);
$pdf->SetX(19);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, Serviços, 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Área Responsável:", 1, 0, 'L', 0);
$pdf->SetX(37);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $tipo_servico[$projectDetail->pro_phase_set[0]], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Data de Abertura:", 1, 0, 'L', 0);
$pdf->SetX(35.5);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, invert_data($projectDetail->pro_created[0]), 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Prioridade:", 1, 0, 'L', 0);
$pdf->SetX(27);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $priority[$idPriority], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Cronograma:", 1, 0, 'L', 0);
$pdf->SetX(30);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $status_s[$statuss], 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Unidade Administrativa:", 1, 0, 'L', 0);
$pdf->SetX(45);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $unidade, 1, 0, 'L', 0);
$pdf->Ln();

//$pdf->SetX(61);
$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Nome do Gestor:", 1, 0, 'L', 0);
$pdf->SetX(35);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $nome_gestor, 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Coor. Relacionamento e Atendimento:", 1, 0, 'L', 0);
$pdf->SetX(63);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, 'JANE T. DA COSTA DIEHL', 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Gerente de Relacionamento:", 1, 0, 'L', 0);
$pdf->SetX(50.5);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, 'ROGERIO DE SOUZA LEITÃO', 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Analista de Relacionamento:", 1, 0, 'L', 0);
$pdf->SetX(50.5);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $nome_analita, 1, 0, 'L', 0);
$pdf->Ln();

$pdf->SetX(11);
$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
$pdf->Cell(55, 5, "Responsável da Área:", 1, 0, 'L', 0);
$pdf->SetX(41);
$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
$pdf->Cell(65, 5, $nome_g_pro, 1, 0, 'L', 0);
$pdf->Ln();

$tmpqueryata = "WHERE ata.id_projeto='" . $projectDetail->pro_id[0] . "'";
$ataprojeto = new request();
$ataprojeto->openAta($tmpqueryata);
$variavel = count($ataprojeto->ata_id);

/*$pdf->SetTextColor(170,85,85); //Cor da fonte vermelha
$pdf->SetFont('helvetica','B',11);
$pdf->Cell(70,8,'Definiçao de Escopo',1,2,'L',0);
$pdf->Cell(190,2,"_______________________________________________________________ ",0,2,'L',0);
$pdf->Ln();*/

if ($projectDetail->pro_t_demada[0] == 1) {
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(70, 8, 'Definição de Erro', 1, 2, 'L', 0);
	$pdf->Cell(190, 2, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Ln();
} else {
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(70, 8, 'Definição de Escopo', 1, 2, 'L', 0);
	$pdf->Cell(190, 2, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Ln();
}

if ($projectDetail->pro_t_demada[0] == "") {
	$pdf->SetTextColor("LightBlue"); //Cor da fonte vermelha
	$pdf->SetXY(11, 120);
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(65, 5, "Em Análise...", 1, 0, 'L', 0);
	$pdf->Ln();
}
//$variavel = 1 ;
if ($variavel == 0) {

	if ($projectDetail->pro_t_demada[0] == 0) {

		$pdf->SetTextColor("LightBlue"); //Cor da fonte vermelha
		$pdf->SetXY(11, 120);
		$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
		$pdf->Cell(65, 5, "Em Análise...", 1, 0, 'L', 0);
		$pdf->Ln();

	} else
		if ($projectDetail->pro_t_demada[0] == 1) {
			//informaçõa de erro 
			$tmpco = " WHERE co.id_projeto = '" . $projectDetail->pro_id[0] . "'";
			$requestco = new request();
			$requestco->openCorretiva($tmpco);
			$countCo = count($requestco->co_id);

			if ($countCo != 0) {

				$pdf->SetTextColor("Black");
				$x = 15;
				$y = 120;
				for ($k = 0; $k < $countCo; $k++) {
					$pdf->SetXY($x, $y);
					//$pdf->SetX(5);
					$pdf->SetTextColor("Black");
					$pdf->SetFont('helvetica', '', 8);
					//$pdf->Cell(280, 6,$requestco->co_descricao[$k], 1, 0, 'L',1); //Erros
					$pdf->Cell(75, 5, "- " . $requestco->co_descricao[$k], 1, 0, 'L', 0);
					$pdf->Ln();
					$y += 5;
					$x = 15;
				}
			} else {

				$pdf->SetTextColor("Black");
				$pdf->SetXY(10, 120);
				$pdf->SetFont('helvetica', '', 8);
				$pdf->Cell(55, 5, "-------", 1, 0, 'L', 0);
			}
		}
} else {
	$pdf->Ln();
	$x = 10;
	$y = 122;
	$pdf->SetTextColor("Black");
	$pdf->SetXY($x, $y);
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "DATA DA REALIZAÇÃO: ", 1, 0, 'L', 0);
	$pdf->SetX(44);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(65, 5, invert_data($ataprojeto->ata_data[0]), 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "INFORMAÇÕES DO GESTOR: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_cliente[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "DESCRIÇÃO DA SITUAÇÃO ATUAL: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_situacao[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "SOLICITAÇÃO DO CLIENTE: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_sol_cliente[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "JUSTIFICATIVA DA SOLICITAÇÃO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_justificativa[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "BENEFÍCIOS: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_beneficio[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "SISTEMAS ENVOLVIDOS: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_sistem_envol[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "TECNOLOGIAS ENVOLVIDAS: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_tecnologia[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "ENTIDADES EXTERNAS ENVOLVIDAS NO DESENVOLVIMENTO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_area_envol[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "CENÁRIO DE DESENVOLVIMENTO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_area_envol[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "CENÁRIOS DE POSSÍVEIS SOLUÇÕES PARA O DESENVOLVIMENTO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_cenario[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "RISCOS EXTERNOS ENVOLVIDOS: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_risco[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "LANÇAMENTO DO PRODUTO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_lancamento[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "CRITÉRIOS DE HOMOLOGAÇÃO: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_homologa[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "CRONOGRAMA SUGERIDO PELO CLIENTE: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_cronograma[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "SUPORTE DE TI: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_suporte[0], 1, 1);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "NECESSIDADE DE TREINAMENTO E/OU CONFECÇÃO DE MATERIAL: ", 1, 0, 'L', 0);
	$pdf->Ln();

	if ($ataprojeto->ata_treinamento[0] == 1) {
		$treina = 'Sim';
	}
	if ($ataprojeto->ata_treinamento[0] == 0) {
		$treina = 'Não';
	}
	if ($ataprojeto->ata_treinamento[0] == 1) {
		if ($ataprojeto->ata_tipo_treino[0] == 0) {
			$material = ' - Virtual';
		}
		if ($ataprojeto->ata_tipo_treino[0] == 1) {
			$material = ' - Presencial ';
		}
	}

	$pdf->SetX(10.5);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(45, 5, "Nescessidade de Treinamento: " . $treina . $material, 1, 0, 'L', 0);
	$pdf->Ln();

	if ($ataprojeto->ata_manual[0] == 1) {
		$manual = 'Sim';
	}
	if ($ataprojeto->ata_manual[0] == 0) {
		$manual = 'Não';
	}

	$pdf->SetX(10.5);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(45, 5, "Nescessidade de Confecção de Material: " . $manual, 1, 0, 'L', 0);
	$pdf->Ln();

	if ($ataprojeto->ata_manual[0] == 1) {
		if ($ataprojeto->ata_tipo_manual[0] == 0) {
			$tipo = ' - Virtual';
		}
		if ($ataprojeto->ata_tipo_manual[0] == 1) {
			$tipo = ' - Impresso ';
		}
	}
	$pdf->SetX(10.5);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(45, 5, "Nescessidade de Manual: " . $manual . $tipo, 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "CONCLUSÕES: ", 1, 0, 'L', 0);
	$pdf->Ln();
	$pdf->SetX(11);

	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->MultiCell(0, 5, $ataprojeto->ata_conclusao[0], 1, 1);
	// 	$pdf->Ln();

	// pega Fases

	function situafase($d) {

		switch ($d) {
			case 0 :
				$t = "Nao Iniciado";
				break;
			case 1 :
				$t = "Em Andamento";
				break;
			case 2 :
				$t = "Concluido";
				break;
			case 3 :
				$t = "Não se Aplica";
				break;
			case 4 :
				$t = "Pendente";
				break;

		}

		return $t;

	}
	//function fase($query,$pdid){
	//Inicio Planejado 1
	$tmpqfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '1'";
	$requestfase = new request();
	$requestfase->openFases($tmpqfas);

	$tmpprofas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '2'";
	$requestpro = new request();
	$requestpro->openFases($tmpprofas);
	//fim Processo 2

	//Inicio Desenvolvimento 3
	$tmpdenfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '3'";
	$requestden = new request();
	$requestden->openFases($tmpdenfas);
	//fim Desenvolvimento 3

	//Inicio Teste 4
	$tmptesfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '4'";
	$requesttes = new request();
	$requesttes->openFases($tmptesfas);
	//fim Teste 4

	//Inicio Homologação 5
	$tmphomfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '5'";
	$requesthom = new request();
	$requesthom->openFases($tmphomfas);
	//fim Homologação 5

	//Inicio Capacitação 6
	$tmpcapfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '6'";
	$requestcap = new request();
	$requestcap->openFases($tmpcapfas);
	//fim Capacitação 6

	//Inicio Implantação 7
	$tmpimpfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '7'";
	$requestimp = new request();
	$requestimp->openFases($tmpimpfas);

	if ($requestfase->fas_dat_ini_plan[0] == "") {
		$pdf->Ln();
		$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
		$pdf->SetFont('helvetica', 'B', 11);
		$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
		$pdf->Cell(-70, -22, "Fases da Demanda", 1, 2, 'L', 0);
		$pdf->SetFont('helvetica', 'B', 8);
		$pdf->SetTextColor(0, 0, 0);
		$pdf->Cell(-70, 34, "Não existe fase da demanda definida", 1, 2, 'L', 0);
		$pdf->SetTextColor(0, 0, 0);
	}
	if (!$requestfase->fas_dat_ini_plan[0] == "") {

		$pdf->Ln();
		$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
		$pdf->SetFont('helvetica', 'B', 11);
		$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
		$pdf->Cell(-70, -22, "Fases da Demanda", 1, 2, 'L', 0);
		$pdf->Ln(20);
		$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 

		// Largura 50, Altura 7, Texto, Com borda, Proximo na mesma Linha, Texto Centralizado, filled cell
		$pdf->Cell(30, 5, $strings["name"], 1, 0, 'C', 1);
		$pdf->Cell(30, 5, $strings["dt_inicop"], 1, 0, 'C', 1);
		$pdf->Cell(30, 5, $strings["dt_fimcop"], 1, 0, 'C', 1);
		$pdf->Cell(30, 5, $strings["dt_inicre"], 1, 0, 'C', 1);
		$pdf->Cell(30, 5, $strings["dt_fimre"], 1, 0, 'C', 1);
		$pdf->Cell(20, 5, $strings["status"], 1, 0, 'C', 1);
		$pdf->SetX(5);

		//Cor e fonte para linha de dados
		$pdf->SetFillColor(234, 234, 235);
		$pdf->SetTextColor(0);
		$pdf->SetFont('');

		//Apresentação da listagem	Fase
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFillColor(255);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Planejamento", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requestfase->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requestfase->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestfase->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requestfase->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requestfase->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Processo
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Requisito", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requestpro->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requestpro->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestpro->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requestpro->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requestpro->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Desenvolvimento
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Desenvolvimento", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requestden->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requestden->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestden->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requestden->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requestden->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Teste
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Teste", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requesttes->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requesttes->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requesttes->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requesttes->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requesttes->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Homologação
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Homologação", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requesthom->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requesthom->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requesthom->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requesthom->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requesthom->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Treinamento
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Treinamento", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requestcap->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requestcap->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestcap->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requestcap->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requestcap->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		//Apresentação da listagem	Implantação
		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, "Implantação", 0, 0, 'L', 0); //Código 
		$pdf->Cell(30, 5, invert_data($requestimp->fas_dat_ini_plan[0]), 0, 0, 'C', 0); //Nome
		$pdf->Cell(30, 5, invert_data($requestimp->fas_dat_fim_plan[0]), 0, 0, 'C', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestimp->fas_dat_ini_real[0]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, invert_data($requestimp->fas_dat_fim_real[0]), 0, 0, 'C', 0); //CNPJ
		$pdf->Cell(20, 5, situafase($requestimp->fas_status[0]), 0, 0, 'C', 0); //Tipo Empresa
		$pdf->SetX(5);

		$pdf->Cell(285, 5, "", 0, 1, 'R', 0);

		if ($ataprojeto->ata_aceite[0] == '1') {
			$pdf->SetX(10);
			$pdf->SetTextColor("Black");
			$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
			$pdf->Cell(55, 5, "Escopo validado pela T.I, data da validação: " . invert_data($ataprojeto->ata_data_aceite[0]), 1, 0, 'L', 0);
			$pdf->Ln();
			$pdf->Cell(55, 10, "Início da realização do cronograma em: $DataFaseDemanda", 1, 0, 'L', 0);
			$pdf->Ln();
		} else {
			$pdf->SetX(10);
			$pdf->SetTextColor("Black");
			$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
			$pdf->Cell(55, 5, "Em processo de validação pela T.I", 1, 0, 'L', 0);
			$pdf->Ln();
			$pdf->Cell(55, 10, "Início da realização do cronograma em: $DataFaseDemanda", 1, 0, 'L', 0);
		}
	}

} //Fecha bloco de escopo

//inicio Solicita mudança 
$tmpimpsom = " WHERE som.id_projeto = '" . $projectDetail->pro_id[0] . "'";
$requestsom = new request();
$requestsom->openMudanca($tmpimpsom);
if ($requestsom->som_id == "") {
	$pdf->Ln();
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Cell(-70, -22, "Solicitação de Mudança", 1, 2, 'L', 0);
	$pdf->SetTextColor("LightBlue"); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(-70, 35, "Não houve solicitação de mudança", 1, 0, 'L', 0);
	$pdf->Ln();

}
if (!$requestsom->som_id == "") {
	$pdf->Ln();
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Cell(-70, -22, "Solicitação de Mudança", 1, 2, 'L', 0);

	$pdf->Ln(20);
	$pdf->SetX(10);

	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->SetFillColor(234, 234, 235);

	// Largura 50, Altura 7, Texto, Com borda, Proximo na mesma Linha, Texto Centralizado, filled cell
	$pdf->Cell(30, 5, $strings["id"], 1, 0, 'C', 1);
	$pdf->Cell(30, 5, $strings["titulo"], 1, 0, 'C', 1);
	$pdf->Cell(30, 5, $strings["dt_abertura"], 1, 0, 'C', 1);
	$pdf->Cell(80, 5, $strings["descricao"], 1, 0, 'L', 1);

	$pdf->SetX(10);

	//Cor e fonte para linha de dados

	//Apresentação da listagem	

	$cont_som = 0;
	for ($k = 0; $k < $a = count($requestsom->som_id); $k++) {
		$b = $k;
		$a_som = $k % 2;
		if ($a_som > 0) {
			$class_som = 'odd';
		} else {
			$class_som = 'even';
		}
		$desc_som = "";
		$desc_som = substr($requestsom->som_descricao[$k], 0, 58);
		$detanha = "DETALHAMENTO: ";

		$pdf->Ln(5);
		$pdf->SetX(10);
		$pdf->SetTextColor(0);
		$pdf->SetFillColor(255);
		$pdf->SetFont('helvetica', '', 8);
		$pdf->Cell(30, 5, $projectDetail->pro_id[0] . "-" . ++ $b, 0, 0, 'L', 0); //Nome
		$pdf->Cell(30, 5, $requestsom->som_titulo[$k], 0, 0, 'L', 0); //Tipo Pessoa
		$pdf->Cell(30, 5, invert_data($requestsom->som_data[$k]), 0, 0, 'C', 0); //CPF
		$pdf->Cell(30, 5, $desc_som . "...", 0, 0, 'L', 0); //CNPJ
		$pdf->SetX(5);

	}
}
$pdf->SetTextColor("Black");

$tmptpro = "WHERE ta.id_projeto = '" . $projectDetail->pro_id[0] . "'";
$requestt = new request();
$requestt->openTermo($tmptpro);
$contt = count($requestt->ter_id);
if ($contt == "") {
	$pdf->Ln();
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Cell(-70, -22, "Pesquisa de Satisfação", 1, 2, 'L', 0);
	$pdf->setTextColor(0, 0, 0);
	$pdf->SetFont('helvetica', 'B', 8);
	$pdf->Cell(-70, 35, "Não existe pesquisa de satisfação", 1, 2, 'L', 0);
}

if ($contt > 0) {

	$pdf->Ln();
	$pdf->SetTextColor(170, 85, 85); //Cor da fonte vermelha
	$pdf->SetFont('helvetica', 'B', 11);
	$pdf->Cell(190, 18, "_______________________________________________________________ ", 0, 2, 'L', 0);
	$pdf->Cell(-70, -22, "Pesquisa de Satisfação", 1, 2, 'L', 0);
	$pdf->Ln(20);
	$pdf->SetX(11);
	$termo = ($requestt->ter_relacionamento[0] + $requestt->ter_comunica[0] + $requestt->ter_alinha[0] + $requestt->ter_solucao[0] + $requestt->ter_prazo[0] + $requestt->ter_performace[0] + $requestt->ter_estabilidade[0] + $requestt->ter_erro[0] + $requestt->ter_atendimento[0] + $requestt->ter_pontualidade[0] + $requestt->ter_ambiente[0] + $requestt->ter_cenario[0]) / 60;

	//echo $termo;

	if ($termo >= 0.80) {
		$pdf->SetTextColor("Black");
		$pdf->SetFont('helvetica', 'B', 9); // font of text inside cells 
		$pdf->Cell(55, 5, "Conclusão da Demanda: - Satisfeito - ", 1, 0, 'L', 0);
		$pdf->Ln();

	} else
		if (($termo < 0.80) && ($termo >= 0.49)) {
			$pdf->SetTextColor("Black");
			$pdf->SetFont('helvetica', 'B', 9); // font of text inside cells 
			$pdf->Cell(55, 5, 'Conclusão da Demanda: - A Desejar -', 1, 0, 'L', 0);
			$pdf->Ln();

		} else
			if ($termo < 0.49) {
				$pdf->SetTextColor("Black");
				$pdf->SetFont('helvetica', 'B', 9); // font of text inside cells 
				$pdf->Cell(55, 5, "Conclusão da Demanda: - Insatisfeito - ", 1, 0, 'L', 0);
				$pdf->Ln();

			}

	function satis($num) {

		switch ($num) {

			case 1 :
				$campo = "Ruin ";
				break;
			case 2 :
				$campo = "Regular";
				break;
			case 3 :
				$campo = "Bom";
				break;
			case 4 :
				$campo = "Otimo";
				break;
			case 5 :
				$campo = "Exelente";
				break;

		}

		return $campo;

	}

	$rel = satis($requestt->ter_relacionamento[0]);
	$pdf->Ln();
	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "1.Relacionamento: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Quanto ao atendimento da demanda o relacionamento foi: " . $rel, 1, 1);

	$comun = satis($requestt->ter_comunica[0]);
	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "2.Comunicação: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "A Comunicação sobre o andamento da demanda foi: " . $comun, 1, 1);

	$alin = satis($requestt->ter_alinha[0]);
	$pdf->SetX(10);
	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "3.Alinhamento com o negócio: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "O alinhamento com a demanda com as necessidades do negócio foram: " . $alin, 1, 1);

	$habi = satis($requestt->ter_solucao[0]);
	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "4.Resolução de problemas: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "A habilidade da equipe em indentificar, definir e solucionar problemas foi: " . $habi, 1, 1);

	$praz = satis($requestt->ter_prazo[0]);
	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "5.Prazo das entregas: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Quanto ao cumprimento dos prazos acordados foram: " . $praz, 1, 1);
	$pdf->SetTextColor("Black");

	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "6.Qualidade de Entrega: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Com relação a qualidade de entrega como foram relalizadas em relação a: ", 1, 1);

	$pdf->SetX(11);
	$perfor = satis($requestt->ter_performace[0]);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Performace - " . $perfor, 1, 1);

	$estab = satis($requestt->ter_estabilidade[0]);
	$pdf->SetX(11);
	$perfor = satis($requestt->ter_performace[0]);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Estabilidade - " . $estab, 1, 1);

	$erros = satis($requestt->ter_erro[0]);
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Geração de erros - " . $erros, 1, 1);

	$pdf->SetTextColor("Black");
	$pdf->SetFont('helvetica', 'B', 8); // font of text inside cells 
	$pdf->Cell(55, 5, "7.Teste e homologação: ", 1, 0, 'L', 0);
	$pdf->Ln();

	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Qual foi a qualidade do teste/homlogação em relação a: ", 1, 1);

	$atend = satis($requestt->ter_atendimento[0]);
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Atendimento - " . $atend, 1, 1);

	$pont = satis($requestt->ter_pontualidade[0]);
	$perfor = satis($requestt->ter_performace[0]);
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Pontualidade - " . $pont, 1, 1);

	$hambie = satis($requestt->ter_ambiente[0]);
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Disponibilidade de ambiente - " . $hambie, 1, 1);

	$cena = satis($requestt->ter_cenario[0]);
	$pdf->SetX(11);
	$pdf->SetFont('helvetica', '', 8); // font of text inside cells 
	$pdf->Cell(0, 5, "Cenários prontos - " . $cena, 1, 1);
	$pdf->Ln();

}

$pdf->Output();
ocilogoff($con);
?>
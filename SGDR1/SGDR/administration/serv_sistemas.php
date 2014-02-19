<?php

#Application name: SGD
#Status page: 1
#Path by root: ../projects/listprojects.php

$checkSession = "true";
include_once ('../includes/library.php');

if (!$profilSession == 6 || !$profilSession == 7) {
	headerFunction('../general/login.php?logout=true');
}

if ($_GET["act"] == "alt") {
	$id_sis = $_REQUEST["sis"];

	$tmpone = "WHERE ID = '".$id_sis."' ";
	$oneSis = new request();
	$oneSis->openSosistema($tmpone);
	

	
	if ($_REQUEST["text_nome"] != '') {
		$tmpupd = "UPDATE ".MYDATABASE.".".$tableCollab['sistema']." SET no_sistema = '".strtoupper(trim($_REQUEST["text_descricao"]))."', " .
				  "co_sistema = '".strtoupper(trim($_REQUEST["text_nome"]))."' WHERE id = ".$_REQUEST["id"]."";

		connectSql($tmpupd);
	}
}

if ($_REQUEST["act"] == "del") {
	
	$id_sis = $_REQUEST["sis"];
	$tmpdel = " WHERE pro.id_sistema = $id_sis";
	$delSis = new request();
	$delSis->openProjects($tmpdel);
	$contDel = count($delSis->pro_id);
	
	if ($contDel > 0) {
		echo $id_org = $resul;
		echo '<script>alert("Existe(m) '.$contDel.' demandas cadastradas para este sistema.");</script>';

		echo $contDel;
		exit;
		/*
		 * Deleta pois tem dois com o mesmo ID
		 * e nao da problema nas demandas
		*/
	} else {
		$tmpdel = "DELETE FROM ".MYDATABASE.".".$tableCollab['sistema']." WHERE id = $id_sis";
		connectSql($tmpdel);
		/*
		 * Deleta e pergunta pra qual sistema passar as demandas
		 * para nao da problema nas demandas existentes
		*/
	}
		
}


if ($text_nome != "" && $text_descricao != "") {
	
	function verificaDuplicado($sigla) {
		$tmp = " WHERE ss.co_sistema = '" . strtoupper(trim($sigla)) . "' ";
		$listSistem = new request();
		$listSistem->openSosistema($tmp);

		$comp = count($listSistem->sis_id);

		return $comp;
	}

	$resul = verificaDuplicado($text_nome);
	
	if ($resul > "0" && $_GET["act"] == "alt") {
		echo '<script>alert("Sistema alterado com com sucesso.");</script>';
		echo '<script>window.location.href="serv_sistemas.php";</script>';
		exit;
	}
	if ($resul > "0") {
		echo '<script>alert("Sistema já existente\nPor favor verifique antes de continuar.");</script>';
		echo '<script>window.history.back(-1);</script>';
		exit;
	} else {
		$tmpcad = "INSERT INTO ".MYDATABASE.".".$tableCollab['sistema']." (co_sistema, no_sistema) VALUES ('" . strtoupper(trim($text_nome))."','".strtoupper(trim($text_descricao))."')";
		connectSql($tmpcad);
		echo '<script>alert("Sistema cadastrado com sucesso.");</script>';
		echo '<script>window.location.href="serv_sistemas.php";</script>';
	}

//	if ($countSis > 0) {
//		echo '<script>alert("Sistema já existente\nPor favor verifique antes de continuar.");</script>';
//		echo '<script>window.history(-1);</script>';
//	} else {
//		$tmpsistem = "INSERT INTO SGD_FNDE.SISTEMAS (ID_SISTEMA, CO_SISTEMA, NU_SEQ_GESTOR_APLICACAO, NO_SISTEMA) VALUES ('".$id_org.", '".strtoupper($text_nome)."', '0', '".strtoupper($text_descricao)."')";
//		connectSql($tmpsistem);
//		echo '<script>alert("Sistema cadastrado com sucesso.");</script>';
//		echo '<script>window.location.href="serv_sistemas.php";</script>';
//	}
}

$tmpall = " ORDER BY NOME";
$allSis = new request();
$allSis->openSisunio("$tmpall");
$countAll = count($allSis->sis_id);

include('../themes/'.THEME.'/header.php');

$block1 = new block();
//$block1->openBreadcrumbs();
//$block1->itemBreadcrumbs($blockPage->buildLink("../administration/admin.php?",$strings["administration"],in));
//$block1->itemBreadcrumbs($blockPage->buildLink("services.php?",$strings["service_management"],in));
//$block1->itemBreadcrumbs($strings["admin_intro"]);
//$block1->closeBreadcrumbs();

$block1->openForm("serv_sistemas.php?act=".$_GET["act"]."","form1");
$block1->openContent("710");

$block1->contentTitle("Incluir Sistema","5");

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","10","","","");
$block1->cellRow("","","","","4");
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("<input type=\"hidden\" name=\"id\" value=\"".$_GET["sis"]."\">&nbsp;&nbsp;","10","","","");
$block1->cellRow("Sigla do Sistema :","110","","","");
$block1->cellRow("<input type=\"text\" name=\"text_nome\" value=\"".$oneSis->sis_nome[0]."\">","590","","","3");
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("Nome do Sistema :","","","","");
$block1->cellRow("<input name=\"text_descricao\" type=\"text\" size=\"60\"  value=\"".$oneSis->sis_decricao[0]."\">","","","","3");
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("","","","","4");
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("<input type=\"submit\" name=\"Submit\" value=\"Salvar\">","","","","4");
$block1->closeRow();

$block1->openRow("on");
echo "<td colspan=\"5\">";
$block1->openResults($checkbox = "false");
$block1->labels($labels = array (
	0 => "Sigla Sistema",
	1 => "Nome Sistema",
	2 => "Alterar",
	3 => "Excluir"
), "true");

for($z=0;$z < $countAll;$z++){

	$block1->openRow("on");
	$block1->cellRow("&nbsp;&nbsp;","","","","");
	$block1->cellRow("".$allSis->sis_unidade[$z]."","","","","");
	$block1->cellRow("".$allSis->sis_nome[$z]."","","","","");

	$block1->cellRow($block1->buildLink("serv_sistemas.php?act=alt&sis=".$allSis->sis_id[$z]."","Alterar","out"),"","","","");
	$block1->cellRow($block1->buildLink("serv_sistemas.php?act=del&sis=".$allSis->sis_id[$z]."","Excluir","out"),"","","","");
}

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("&nbsp;","","","","2");
$block1->cellRow("&nbsp;","","","","2");
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("<b>TOTAL DE SISTEMAS : $countAll</b>","","","","2");
$block1->cellRow("&nbsp;","","","","2");
$block1->closeRow();

$block1->closeContent();

echo "</td>";
$block1->closeRow();

$block1->openRow("on");
$block1->cellRow("&nbsp;&nbsp;","","","","");
$block1->cellRow("&nbsp;","","","","4");
$block1->closeRow();

$block1->closeContent();


$block1->closeForm();


include('../themes/'.THEME.'/footer.php');

?>

<?php

/*
** Application name: SGD
** Last Edit page: 2006-04-08 
** Path by root: ../projects/editproject.php
** Authors: Luciano / lucianoct188@gmail.com
**
** =============================================================================
**
**               SGD - Project Managment 
**
** -----------------------------------------------------------------------------
** Please refer to license, copyright, and credits in README.TXT
**
** -----------------------------------------------------------------------------
** FILE: editproject.php
**
** DESC: Screen: Create or edit a project
**
** HISTORY:
**  2006-05-08	-	fixed null value for hourly rate
** -----------------------------------------------------------------------------
** TO-DO:
** =============================================================================
*/

$checkSession = "true";
include_once ('../includes/library.php');
include ("../includes/customvalues.php");

$id = returnGlobal('id', 'REQUEST');
$docopy = returnGlobal('docopy', 'REQUEST');

// -- INI REMOVE FASE DA DEMANDA
if (($removefase == "true") && ($idproject != "")) {

	$tmpquery1 = " DELETE FROM " . MYDATABASE . ".".$tableCollab["fases"]." WHERE id_projeto='" . $idproject . "'";
	connectSql("$tmpquery1");
	headerFunction("viewproject.php?id=" . $idproject . "&" . session_name() . "=" . session_id());
	/* echo "<script>window.location.href='viewproject.php?id=".$idprojeto."&docopy=false&".session_name()."=".session_id()."';</script>";  */
	exit;
}
// -- FIM REMOVE FASE DA DEMANDA

//INI -- REMOVE INFORMAÇÕES DE ERRO
if (($evento == "true") && (!$idvalor == "") && (!$iderro == "")) {

	//inicio image de erro 
	$tmpco = " WHERE co.id = '" . $iderro . "'";
	$requestco = new request();
	$requestco->openCorretiva($tmpco);
	$countCo = count($requestco->co_id);
	//fim image de erro 

	chmod("$requestco->co_erro[0]", 0777);
	$arquivo = $requestco->co_erro[0];
	if ($ok = unlink($arquivo)) {

		//echo "--sucesso";
		//exit;
	} else {

		//echo "nao encontrou".$requestco->co_erro[0];
		//exit;
	}
	unset ($requestco);
	$tmpquery1 = " DELETE FROM " . MYDATABASE . ".".$tableCollab["projects_corretiva"]." WHERE id='" . $iderro . "'";
	connectSql("$tmpquery1");
	headerFunction("viewproject.php?id=" . $idvalor . "&" . session_name() . "=" . session_id());
	/*echo "<script>window.location.href='viewproject.php?id=".$idvalor."&".session_name()."=".session_id()."';</script>"; */
	exit;
}
//FIM -- REMOVE INFORMAÇÕES DE ERRO

// funçao trada statuss da demanda 
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

	//Status da fase.
	$st_fase = $requestimp2->fas_status[0];

	$dat_pla_1 = $requestfase1->fas_dat_ini_plan[0];
	$dat_pla_2 = $requestimp2->fas_dat_fim_plan[0];

	$dat_pla_3 = $requestfase1->fas_dat_ini_real[0];
	$dat_pla_4 = $requestimp2->fas_dat_fim_real[0];

	$statuss = fase_status($dat_pla_1, $dat_pla_2, $dat_pla_3, $dat_pla_4, $st_fase);

	return $statuss;

}

function faseconsul($id) {
	$tmpquery = "WHERE fas.id_projeto = '" . $id . "' AND fas.status_fase IN(0,1,2,3)";
	$testfases = new request();
	$testfases->openFases($tmpquery);
	$comptfases = count($testfases->fas_id);

	if ($comptfases > 0) {

		$valor = "1";

	} else {

		$valor = "0";

	}

	return $valor;

}

function faseconsulta($id) {
	$tmpquery = "WHERE fas.id_projeto = '" . $id . "'";
	$testfases = new request();
	$testfases->openFases($tmpquery);
	$comptfases = count($testfases->fas_id);

	if ($comptfases > 0) {

		$valor = "1";

	} else {

		$valor = "0";

	}

	return $valor;

}

//--INI -- REMOVE DEFINIÇÃO DE ESCOPO
if (($evento == "true") && (!$idvalor == "") && (!$idscopo == "")) {
	//inicio ata reuniao 
	$tmpimpatar1 = " WHERE atn.id = '" . $idscopo . "'";
	$requestatar = new request();
	$requestatar->openAtaanexo($tmpimpatar1);
	//fim ata reuniao	

	if ($ok = unlink(trim($requestatar->atan_documento[0]))) {

		//echo "--sucesso";
		// exit;
	} else {

		//echo "nao encontrou".$requestatar->atan_documento[0];
		//exit;
	}
	unset ($requestatar);
	$tmpquery1 = "DELETE FROM ".MYDATABASE.".".$tableCollab["ata_anexo"]." WHERE id='" . $idscopo . "'";
	connectSql("$tmpquery1");
	headerFunction("viewproject.php?id=" . $idvalor . "&" . session_name() . "=" . session_id());
	/*echo "<script>window.location.href='viewproject.php?id=".$idvalor."&".session_name()."=".session_id()."';</script>"; */
	exit;
}
//--FIM -- REMOVE DEFINIÇÃO DE ESCOPO

//if($addfase=="true"){
if (!$text_fase == "") {
	if ($profilSession != 7) {
		$gfase = faseconsulta($id);
		
		if ($gfase == 0) {
			
			//Updata planejamento
			

			//ALTERA COMPLEXIDADE
			if (!$select_complex == "") {
				$tmpcomplex = "UPDATE ".MYDATABASE.".".$tableCollab["projects"]." SET hourly_rate='" . $select_complex . "' WHERE id = '$id' ";
				connectSql("$tmpcomplex");
			}
			//

			$tmpqueryiplan = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase,data_fase) VALUES('" . data_invert($text_fase) . "','" . data_invert($text_fase_dfimp) . "','" . data_invert($text_fase_dinir) . "','" . data_invert($text_fase_dfimr) . "','1','$id','$m_pla','" . date('d-m-Y') . "')";
			connectSql("$tmpqueryiplan");

			//Updata processo
			$tmpqueryipro = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($text_pro) . "','" . data_invert($text_pro_dfimp) . "','" . data_invert($text_pro_dinir) . "','" . data_invert($text_pro_dfimr) . "','2','$id','$m_pro')";
			connectSql("$tmpqueryipro");

			//Updata Desenvolvimento
			$tmpqueryiden = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($text_den) . "','" . data_invert($text_den_dfimp) . "','" . data_invert($text_den_dinir) . "','" . data_invert($text_den_dfimr) . "','3','$id','$m_den')";
			connectSql("$tmpqueryiden");

			//insert Teste
			$tmpqueryites = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($text_tes) . "','" . data_invert($text_tes_dfimp) . "','" . data_invert($text_tes_dinir) . "','" . data_invert($text_tes_dfimr) . "','4','$id','$m_tes')";
			connectSql("$tmpqueryites");

			//insert homologa
			$tmpqueryihom = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($text_hom) . "','" . data_invert($text_hom_dfimp) . "','" . data_invert($text_hom_dinir) . "','" . data_invert($text_hom_dfimr) . "','5','$id','$m_hom')";
			connectSql("$tmpqueryihom");

			//insert treinamento
			$tmpqueryitre = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($text_cap) . "','" . data_invert($text_cap_dfimp) . "','" . data_invert($text_cap_dinir) . "','" . data_invert($text_cap_dfimr) . "','6','$id','$m_trei')";
			connectSql("$tmpqueryitre");

			//insert Implantação
			$d_text_imp = data_invert($text_imp);
			$tmpqueryiimp = "INSERT INTO ".MYDATABASE."." . $tableCollab["fases"] . "( data_ini_plan,data_fim_plan,data_ini_real,data_fim_real,tipo_fase,id_projeto,status_fase) VALUES('" . data_invert($d_text_imp) . "','" . data_invert($text_imp_dfimp) . "','" . data_invert($text_imp_dinir) . "','" . data_invert($text_imp_dfimr) . "','7','$id','$m_impla')";
			connectSql("$tmpqueryiimp");
			
			$addfase = "false";

			//headerFunction("../projects/viewproject.php?id=$id&".session_name()."=".session_id());
			//exit;

		} else
			if ($gfase > 0) {

				//ALTERA COMPLEXIDADE
				if (!$select_complex == "") {
					$tmpcomplex = "UPDATE ".MYDATABASE.".".$tableCollab["projects"]." SET hourly_rate='" . $select_complex . "' WHERE id = '$id' ";
					connectSql("$tmpcomplex");
				}
				//	
				//Updata planejamento
				if (data_invert($text_fase) > data_invert($text_fase_dfimp)) {
					echo '<script>alert("A data de Planejado em Planejamento, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_fase_dinir) > data_invert($text_fase_dfimr)) {
					echo '<script>alert("A data de Realizado em Planejamento, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpquerypla = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_fase) . "', data_fim_plan='" . data_invert($text_fase_dfimp) . "',data_ini_real='" . data_invert($text_fase_dinir) . "',data_fim_real='" . data_invert($text_fase_dfimr) . "',status_fase='$m_pla' WHERE id_projeto = '$id' and tipo_fase='1'";
				connectSql("$tmpquerypla");

				//Updata processo
				if (data_invert($text_pro) > data_invert($text_pro_dfimp)) {
					echo '<script>alert("A data de Planejado em Processo, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_pro_dinir) > data_invert($text_pro_dfimr)) {
					echo '<script>alert("A data de Realizado em Processo, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpquerypro = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_pro) . "', data_fim_plan='" . data_invert($text_pro_dfimp) . "',data_ini_real='" . data_invert($text_pro_dinir) . "',data_fim_real='" . data_invert($text_pro_dfimr) . "',status_fase='$m_pro' WHERE id_projeto = '$id' and tipo_fase='2'";
				connectSql("$tmpquerypro");

				//Updata desenvolvimento
				if (data_invert($text_den) > data_invert($text_den_dfimp)) {
					echo '<script>alert("A data de Planejado em Desenvolvimento, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_den_dinir) > data_invert($text_den_dfimr)) {
					echo '<script>alert("A data de Realizado em Desenvolvimento, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpqueryden = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_den) . "', data_fim_plan='" . data_invert($text_den_dfimp) . "',data_ini_real='" . data_invert($text_den_dinir) . "',data_fim_real='" . data_invert($text_den_dfimr) . "',status_fase='$m_den' WHERE id_projeto = '$id' and tipo_fase='3'";
				connectSql("$tmpqueryden");

				//Updata Teste
				if (data_invert($text_tes) > data_invert($text_tes_dfimp)) {
					echo '<script>alert("A data de Planejado em Teste, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_tes_dinir) > data_invert($text_tes_dfimr)) {
					echo '<script>alert("A data de Realizado em Teste, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpquerytes = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_tes) . "', data_fim_plan='" . data_invert($text_tes_dfimp) . "',data_ini_real='" . data_invert($text_tes_dinir) . "',data_fim_real='" . data_invert($text_tes_dfimr) . "',status_fase='$m_tes' WHERE id_projeto = '$id' and tipo_fase='4'";
				connectSql("$tmpquerytes");

				//Updata Homologa
				if (data_invert($text_hom) > data_invert($text_hom_dfimp)) {
					echo '<script>alert("A data de Planejado em Homologação, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_hom_dinir) > data_invert($text_hom_dfimr)) {
					echo '<script>alert("A data de Realizado em Homologação, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpqueryhom = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_hom) . "', data_fim_plan='" . data_invert($text_hom_dfimp) . "',data_ini_real='" . data_invert($text_hom_dinir) . "',data_fim_real='" . data_invert($text_hom_dfimr) . "',status_fase='$m_hom' WHERE id_projeto = '$id' and tipo_fase='5'";
				connectSql("$tmpqueryhom");

				//Updata treinamento
				if (data_invert($text_cap) > data_invert($text_cap_dfimp)) {
					echo '<script>alert("A data de Planejado em Treinamento, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_cap_dinir) > data_invert($text_cap_dfimr)) {
					echo '<script>alert("A data de Realizado em Treinamento, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpquerytre = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_cap) . "', data_fim_plan='" . data_invert($text_cap_dfimp) . "',data_ini_real='" . data_invert($text_cap_dinir) . "',data_fim_real='" . data_invert($text_cap_dfimr) . "',status_fase='$m_trei' WHERE id_projeto = '$id' and tipo_fase='6'";
				connectSql("$tmpquerytre");

				//Updata Implatação
				if (data_invert($text_imp) > data_invert($text_imp_dfimp)) {
					echo '<script>alert("A data de Planejado em Implantação, Inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				if (data_invert($text_imp_dinir) > data_invert($text_imp_dfimr)) {
					echo '<script>alert("A data de Realizado em Implantação, inicio e maior que Fim !");</script>';
					echo '<script>history.back(-1);</script>';
					exit;
				}
				$tmpqueryimp = "UPDATE ".MYDATABASE."." . $tableCollab["fases"] . " SET data_ini_plan='" . data_invert($text_imp) . "', data_fim_plan='" . data_invert($text_imp_dfimp) . "',data_ini_real='" . data_invert($text_imp_dinir) . "',data_fim_real='" . data_invert($text_imp_dfimr) . "',status_fase='$m_impla' WHERE id_projeto = '$id' and tipo_fase='7'";
				connectSql("$tmpqueryimp");

				$addfase = "false";
				/*echo '<script>alert("Registrado com Sucesso!");</script>'; */
				//headerFunction("../projects/viewproject.php?id=$id&".session_name()."=".session_id());
				//exit;

			} // if profilsession
	}

	//headerFunction("viewproject.php?id=$id&".session_name()."=".session_id());
	//exit;

}

//case update or copy project
if ($id != "") {
	if ($profilSession != 0 && $profilSession != 1 && $profilSession != 6 && $profilSession != 7 && $profilSession != 10) {
		headerFunction("../projects/viewproject.php?id=$id&" . session_name() . "=" . session_id());
		exit;
	}

	if (!$addf == "") {

		$date_fase = date('Y-m-d');
		$tmpqueryd = "INSERT INTO ".MYDATABASE."." . $tableCollab["ata_reuniao"] . "(id_relaciona,id_projeto,data) VALUES('$idSession','$addf','$date_fase')";
		//exit;
		connectSql("$tmpqueryd");
		headerFunction("../projects/editproject.php?id=$id&" . session_name() . "=" . session_id());
		exit;
	}

	//test exists selected project, redirect to list if not
	$tmpquery = " WHERE pro.id = '$id'";
	$projectDetail = new request();
	$projectDetail->openProjects($tmpquery);
	$comptProjectDetail = count($projectDetail->pro_id);

	if ($comptProjectDetail == "0") {
		headerFunction("../projects/listprojects.php?msg=blankProject&" . session_name() . "=" . session_id());
		exit;
	}

	if ($idSession != $projectDetail->pro_owner[0] && $profilSession != 0 && $profilSession != 6 && $profilSession != 7 && $profilSession != 10) {
		headerFunction("../projects/listprojects.php?msg=projectOwner&" . session_name() . "=" . session_id());
		exit;
	}

	if (($profilSession == 7) && ($projectDetail->pro_men_analista[0] != $idSession)) {
		headerFunction("../projects/viewproject.php?id=$id&" . session_name() . "=" . session_id());
		exit;
	}

	//case update or copy project
	if ($action == "update") {

		//replace quotes by html code in name and description
		$pn = convertData($pn);
		$d = convertData($d);

		//case copy project
		if ($docopy == "true") {

			if ($invoicing == "" || $clod == "1") {
				$invoicing = "0";
			}

			if ($hourly_rate == "") {
				$hourly_rate = "0.00";
			}

			//insert into projects and teams (with last id project)
			//$tmpquery1 = "INSERT INTO ".$tableCollab["projects"]."(name,priority,description,owner,organization,status,created,published,upload_max,url_dev,url_prod,phase_set,invoicing,hourly_rate,tipo_demanda) VALUES('$pn','$pr','$d','$pown','$clod','$st','$dateheure','$projectPublished','$up','$url_dev','$url_prod','$thisPhase','$invoicing','$hourly_rate','$tipodemanda')";
			//connectSql("$tmpquery1");
			//$tmpquery = $tableCollab["projects"];
			//last_id($tmpquery);
			//$projectNew = $lastId[0];
			unset ($lastId);
			if ($idSession != $pown) {
				//echo $tmpquery2 = "INSERT INTO ".$tableCollab["teams"]."(project,member,published,authorized) VALUES('$projectNew','$pown','1','0')";
				//connectSql("$tmpquery2");
				//exit;
			}

			

			

			if ($htaccessAuth == "true") {

				$content =<<<STAMP
AuthName "$setTitle"
AuthType Basic
Require valid-user
AuthUserFile $fullPath/files/$projectNew/.htpasswd
STAMP;
				$fp = @ fopen("../files/$projectNew/.htaccess", 'wb+');
				$fw = fwrite($fp, $content);
				$fp = @ fopen("../files/$projectNew/.htpasswd", 'wb+');

				$tmpquery = " where mem.id = '$pown'";
				$detailMember = new request();
				$detailMember->openMembers($tmpquery);

				$Htpasswd = new Htpasswd;
				$Htpasswd->initialize("../files/" . $projectNew . "/.htpasswd");
				$Htpasswd->addUser($detailMember->mem_login[0], $detailMember->mem_password[0]);
			}

			
			//if mantis bug tracker enabled
			if ($enableMantis == "true") {
				// call mantis function to copy project
				//include("$pathMantis/proj_add.php");
			}

			//if CVS repository enabled
			if ($enable_cvs == "true") {
				//$user_query = "AND mem.id = '$pown'";
				//$cvsUser = new request();
				//$cvsUser->openMembers($user_query);
				//cvs_add_repository($cvsUser->mem_login[0], $cvsUser->mem_password[0], $projectNew);
			}

			//create phase structure if enable phase was selected as true
			if ($thisPhase != "0") {
				$comptThisPhase = count($phaseArraySets[$thisPhase]);
				
			}

			headerFunction("../projects/viewproject.php?id=$projectNew&msg=add&" . session_name() . "=" . session_id());

		} else {

			//if project owner change, add new to team members (only if doesn't already exist)
			if ($pown != $projectDetail->pro_owner[0]) {
				$tmpquery = " WHERE tea.project = '$id' AND tea.member = '$pown'";
				$testinTeam = new request();
				$testinTeam->openTeams($tmpquery);
				$comptTestinTeam = count($testinTeam->tea_id);

				if ($comptTestinTeam == "0") {
					

					if ($htaccessAuth == "true") {
						
					}
				}
			}

			//if organization change, delete old organization permitted users from teams
			if ($clod != $projectDetail->pro_organization[0]) {
				$tmpquery = " WHERE tea.project = '$id' AND mem.profil = '3'";
				$suppTeamClient = new request();
				$suppTeamClient->openTeams($tmpquery);
				$comptSuppTeamClient = count($suppTeamClient->tea_id);

				if ($comptSuppTeamClient == "0") {
					for ($i = 0; $i < $comptSuppTeamClient; $i++) {
						$membersTeam .= $suppTeamClient->tea_mem_id[$i];
						if ($i < $comptSuppTeamClient -1) {
							$membersTeam .= ",";
						}

						if ($htaccessAuth == "true") {
							$Htpasswd->initialize("../files/" . $id . "/.htpasswd");
							$Htpasswd->deleteUser($suppTeamClient->mem_login[$i]);
						}
					}

					$tmpquery4 = "DELETE FROM ".MYDATABASE."." . $tableCollab["teams"] . " WHERE project = '$id' AND member IN($membersTeam)";
					connectSql("$tmpquery4");
				}
			}

			//-------------------------------------------------------------------------------------------------		
			$tmpquery = " WHERE pro.id = '$id'";
			$targetProject = new request();
			$targetProject->openProjects($tmpquery);

			//Delete old or unused phases
			if ($targetProject->pro_phase_set[0] != $thisPhase) {
				$tmpquery = "DELETE FROM " . $tableCollab["phases"] . " WHERE project_id = $id";
				//connectSql("$tmpquery");
			}

			//Create new Phases
			if ($targetProject->pro_phase_set[0] != $thisPhase) {
				$comptThisPhase = count($phaseArraySets[$thisPhase]);

				for ($i = 0; $i < $comptThisPhase; $i++) {
					$tmpquery = "INSERT INTO " . $tableCollab["phases"] . "(project_id,order_num,status,name) VALUES('$id','$i','0','" . $phaseArraySets[$thisPhase][$i] . "')";
					//connectSql("$tmpquery");
				}

			}

			//update project
			if ($invoicing == "" || $clod == "1") {
				//nb if the project has not client than the invocing will be deactivated
				$invoicing = "0";
			}

			//indentificaçao da demanda 

			if ($mosindent == 1) {
				if ($profilSession == 6 || $profilSession == 0 || $profilSession == 9) {
					if ($select_servico == "") {
						$phaset = "";
					} else {
						$phaset = ", phase_set='$select_servico'";
					}
					//phase_set='$thisPhase'hourly_rate='$hourly_rate',phase_set='1',upload_max='$up'
					$tmpquery = "UPDATE ".MYDATABASE."." . $tableCollab["projects"] . " SET name='$pn',priority='$pr',url_dev='$select_scala',url_prod='$url_prod',owner='$pown',organization='$clod',status='$st',modified='$dateheure',invoicing='$invoicing',tipo_demanda='$tipodemanda',id_cora='$powncoo',id_ger_pro='$gpro',id_sistema='$select_name',id_relacionamento='$select5',id_cordenacao='$select_an',id_analista='$select_an',id_fabrica='$select_cfab' $phaset WHERE id = '$id'";
					connectSql("$tmpquery");
					//exit;

					//-------------------------//
					$tmpgest = " where ( mem.profil = '7' AND mem.id ='" . $pown . "' )";
					$usergest = new request();
					$usergest->openMembers($tmpgest);
					$contgest = count($usergest->mem_id);

					if ($contgest == 0) {
						$tmpqueryy = " WHERE tea.project = '$id' AND tea.member = '$pown'";
						$amClientt = new request();
						$amClientt->openTeams($tmpqueryy);
						$CamClientt = count($amClientt->tea_id);

						if ($CamClientt < 1) {
							if ($idSession != $pown) {
								if ($pown != "") {
									$tmptems = "INSERT INTO " . $tableCollab["teams"] . "(project,member,published ,authorized) VALUES('$id','$pown','1','0')";
									connectSql("$tmptems");
								}
							}
						}
					}
					//-------------------------//		

					if ($st == 5) {
						//habilita invoicig para mostra messagem para gestor confirmar prazo conograma
						$tmpinvo = "UPDATE ".MYDATABASE."." . $tableCollab["projects"] . " SET invoicing='1' WHERE id = '$id'";
						connectSql("$tmpinvo");
					}
					$tmpmver = " WHERE tea.project ='$id' and tea.member= '" . $gpro . "' ";
					$verrequest = new request();
					$verrequest->openTeams($tmpmver);
					$countver = count($verrequest->tea_id);
					//retira demais gerente de projeto.
					if ($countver < 1) {
						if (!$gpro == "") {

							$tmpquery = " WHERE tea.project = '$id' AND mem.profil = '1'";
							$amClient = new request();
							$amClient->openTeams($tmpquery);
							$CamClient = count($amClient->tea_id);
							for ($i = 0; $i < $CamClient; $i++) {
								$tmpquery1 = "DELETE FROM sgd_fnde.teams WHERE project='$id' AND member='" . $amClient->tea_member[$i] . "'";
								connectSql("$tmpquery1");
								//exit;
							}

							if (($countver < 1) || ($verrequest->tea_member[0] == $gpro)) {

								if ($gpro != "") {
									$tmptems = "INSERT INTO " . $tableCollab["teams"] . "(project,member,published ,authorized) VALUES('$id','$gpro','1','0')";
									connectSql("$tmptems");
									/*
									     //GERA LOG
										$gera = new arquivo();
										$dat = date('Ymd');
										$hor = date('Hi');
									
										$dateh = date('Y-m-d');
										$hora = date("H")-3;
										$minu = date(':i');
										$dateheure1 = invert_data($dateh)." ".$hora.$minu;
									
										$oi = $gera->gera($dat,$hor);
										$tmpp =" AND SU.nu_seq_usuario = '".$gpro."' ";
									       $user_gerente = new request();
									       $user_gerente->openUserpro($tmpp);
										//echo $user_analista->usu_name[0];
										$tmpmail = "where ( SU.id ='".$gpro."') " ;
										$usermail = new request();
										$usermail->openMembers($tmpmail);	
										$contmail = count($usermail->mem_id);
										for($um=0; $um < $contmail ;$um++){
										$envimail = new email();
									       $envimail->enviar('Alterado Gerente de projeto pela Coordenação',' Demanda numero '.$id.' - '.$pn.',  Atribuido gerente :'.$user_gerente->usu_name[0].' ',$usermail->mem_email_work[$um]);
									
										$oii = $gera->insert($dateheure1." EXECUTADO POR:".$nameSession.", Demanda ".$id." - ".$pn.": Atribuido gerente :".$user_gerente->usu_name[0].". <br>",$oi);
										unset($usermail);
										unset($oii);
										}
										//GERA REFERENCIA
										$gera->referencia($dateh,'1',$id,'Alterado Gerente de projeto pela Coordenação',$oi);
									*/

								}

							}

						}
					}

					/*
					if($countver < 1){
						if(!$gpro==""){
						$tmptems = "INSERT INTO ".$tableCollab["teams"]."(project,member,published ,authorized) VALUES('$id','$gpro','1','0')";
						//connectSql("$tmptems");
						}
					}
					        */
					//envia informação em analise
					if ($st == 1) {
						/*
						//GERA LOG
							$gera = new arquivo();
							$dat = date('Ymd');
							$hor = date('Hi');
						
							$dateh = date('Y-m-d');
							$hora = date("H")-3;
							$minu = date(':i');
							$dateheure1 = invert_data($dateh)." ".$hora.$minu;
						
							$oi = $gera->gera($dat,$hor);
							$tmpp =" AND SU.nu_seq_usuario = '".$select_analist."' ";
						       $user_analista = new request();
						       $user_analista->openUserpro($tmpp);
							//echo $user_analista->usu_name[0];
							
						$tmpmail = "AND ( SU.nu_seq_usuario ='".$select_analist."' OR SU.nu_seq_usuario ='".$pown."') " ;
						$usermail = new request();
						$usermail->openMembers($tmpmail);	
						$contmail = count($usermail->mem_id);
						for($um=0; $um < $contmail ;$um++){
						//$enviar = "true";
						$envimail = new email();
						$envimail->enviar('Demanda Em Analise',' Demanda numero '.$id.' - '.$pn.'  <br>neste momento está sendo analisada pelo(a) analista de relacionamento '.strtolower($user_analista->usu_name[0]).'',$usermail->mem_email_work[$um]);
						$oi = $gera->insert($dateheure1." EXECUTADO POR:".$nameSession.", ENVIADO EMAIL PARA :".$usermail->mem_email_work[$um].". <br><br>",$oi);
									    
						unset($envimail);
						
						}
						*/
						//GERA REFERENCIA
						$gera->referencia($dateh, '1', $id, 'Em Analise', $oi);
					}
					//fim envia informação em analise

				} else {
					if ($profilSession == 7) {

						//CAPTURA GESTOR
						$tmpgest = " AND SU.nu_seq_usuario = '" . $pown . "' ";
						$user_gest = new request();
						$user_gest->openUserpro($tmpgest);
						//echo $user_gest->usu_name[0];

						//CAPTURA ANALISTA 
						$tmpp = " AND SU.nu_seq_usuario = '" . $select_analist . "' ";
						$user_analista = new request();
						$user_analista->openUserpro($tmpp);
						//$user_analista->usu_name[0];

						if ($tipodemanda == 3) {
							$alt_demanda = " ,id_ger_pro='$gpro' ";
						} else {
							$alt_demanda = "";
						}

						if ($select_servico == "") {
							$phaset = "";
						} else {
							$phaset = ", phase_set='$select_servico'";
						}

						$tmpquery = "UPDATE ".MYDATABASE."." . $tableCollab["projects"] . " SET name='$pn',status='$st',id_sistema='$select_name',owner='$pown',organization='$clod',url_dev='$select_scala', tipo_demanda='$tipodemanda'  $alt_demanda  $phaset WHERE id = '$id'";
						connectSql("$tmpquery");

						//GERA LOG
						$gera = new arquivo();
						$dat = date('Ymd');
						$hor = date('Hi');

						$dateh = date('Y-m-d');
						$hora = date("H") - 3;
						$minu = date(':i');
						$dateheure1 = invert_data($dateh) . " " . $hora . $minu;

						//----------VERIFICA USUARIO DE SERVIÇO---------------//
						if ($tipodemanda == 3) {
							$tmpmver = " WHERE tea.project ='$id' and tea.member= '" . $gpro . "' ";
							$verrequest = new request();
							$verrequest->openTeams($tmpmver);
							$countver = count($verrequest->tea_id);

							if ($countver < 1) {

								//RETIRA USUARIO DE SERVIÇO.
								$tmpquery = " WHERE tea.project = '$id' AND (mem.profil = '11' OR mem.profil = '1')";
								$amClient = new request();
								$amClient->openTeams($tmpquery);
								$CamClient = count($amClient->tea_id);
								for ($i = 0; $i < $CamClient; $i++) {
									$tmpquery1 = "DELETE FROM sgd_fnde.teams WHERE project='$id' AND member='" . $amClient->tea_member[$i] . "'";
									connectSql("$tmpquery1");
									//exit;
								}
								//RETIRA USUARIO DE SERVIÇO.

								if (!$gpro == "") {

									$tmptems = "INSERT INTO " . $tableCollab["teams"] . "(project,member,published ,authorized) VALUES('$id','$gpro','1','0')";
									connectSql("$tmptems");
								}
							}
						}
						//-----------VERIFICA USUARIO DE SERVIÇO--------------//

						//-------------------------//
						//INI RETIRA GESTOR.
						$tmpquery = " WHERE tea.project = '$id' AND mem.profil = '3' AND pro.owner = mem.id ";
						$amClient = new request();
						$amClient->openTeams($tmpquery);
						$CamClient = count($amClient->tea_id);
						for ($i = 0; $i < $CamClient; $i++) {
							$tmpquery1 = "DELETE FROM sgd_fnde.teams WHERE project='$id' AND member='" . $amClient->tea_member[$i] . "'";
							connectSql("$tmpquery1");
							//exit;
						}
						//FIM RETIRA GESTOR.
						//-------------------------//
						// INSERE GESTOR
						$tmpqueryy = "WHERE tea.project = '$id' AND tea.member = '$pown'";
						$amClientt = new request();
						$amClientt->openTeams($tmpqueryy);
						$CamClientt = count($amClientt->tea_id);
						//exit;					
						if ($CamClientt < 1) {

							if (!$pown == "") {
								//echo "<br>qtd1-".$idSession."--".$pown; exit;
								if ($idSession != $pown) {

									$tmpno = " AND (SU.nu_seq_usuario = '" . $pown . "'  AND ( mem.profil = '6' OR mem.profil = '7' OR mem.profil = '10')  ) ";
									$userno = new request();
									$userno->openMembers($tmpno);
									$contno = count($userno->mem_id);

									if ($contno < 1) {
										$tmptems = "INSERT INTO " . $tableCollab["teams"] . "(project,member,published ,authorized) VALUES('$id','$pown','1','0')";
										connectSql("$tmptems");

										//AÇÃO
										$dat = date('Ymd');
										$hor = date('Hi');

										$dateh = date('Y-m-d');
										$hora = date("H") - 3;
										$minu = date(':i');

										$dateheure2 = invert_data($dateh) . " " . $hora . $minu;

										$acao = new arquivo();
										$faz = $acao->gera($dat, $hor . date('B'));
										if ($profilSession == 6) {
											$pessoa = "COORDENADOR";
										} else
											if ($profilSession == 7) {
												$pessoa = "ANALISTA";
											}
										//INI PEGA NOVO GESTOR
										//$pown
										$tmpg = " AND SU.nu_seq_usuario = '" . $pown . "'";
										$usernog = new request();
										$usernog->openMembers($tmpg);
										//FIM PEGA NOVO GESTOR

										$fazz = $acao->insert($dateheure2 . " EXECUTADO POR " . $pessoa . " : " . $nameSession . " <br>AÇÃO : ALTERADO GESTOR - GESTOR DA DEMANDA ATUAL  : " . $usernog->mem_name[0] . " .<br><br>", $faz);
										$acao->referencia($dateh, '3', $id, 'Alterado Gestor', $faz);
										unset ($fazz);
										unset ($faz);
										unset ($acao);
										//FIM AÇÃO

									}
								}
							}

						}
						// INSERE GESTOR
						//-------------------------//

						if ($st == 5) {
							//habilita invoicig para mostra messagem para gestor confirmar prazo conograma
							$tmpinvo = "UPDATE " . $tableCollab["projects"] . " SET invoicing='1' WHERE id = '$id'";
							connectSql("$tmpinvo");

							//echo '$powg';
							$tmpmail = " AND ( mem.profil = '6' OR SU.nu_seq_usuario = '" . $powg . "' ) ";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							$contmail = count($usermail->mem_id);
							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								//$envimail->enviar('Validado pela TI',' Demanda numero '.$id .' - '.$pn.',  <br>foi validada pela TI e Cronograma foi criado. ',$usermail->mem_email_work[$um]);
								unset ($envimail);
							}
							//INI AÇÃO
							if ($profilSession == 6) {
								$pessoa = "COORDENADOR";
							} else
								if ($profilSession == 7) {
									$pessoa = "ANALISTA";
								}

							$dat = date('Ymd');
							$hor = date('Hi');
							$dateh = date('Y-m-d');
							$hora = date("H") - 3;
							$minu = date(':i');

							$dateheure2 = invert_data($dateh) . " " . $hora . $minu;
							$acao = new arquivo();
							$faz = $acao->gera($dat, $hor . date('B') . "vt");
							$fazz = $acao->insert($dateheure2 . " EXECUTADO POR " . $pessoa . ": " . $nameSession . " <br>AÇÃO : Validado pela TI  - GESTOR DA DEMANDA ATUAL  :" . $user_gest->usu_name[0] . " .<br><br>", $faz);
							$acao->referencia($dateh, '3', $id, 'Validado pela TI', $faz);
							unset ($fazz);
							unset ($faz);
							unset ($acao);
							//FIM AÇÃO

						}

						//envia informação em analise
						if ($st == 1) {

							$oi = $gera->gera($dat, $hor);
							//echo "fez gera".$oi;

							//$oiii = $gera->abrir($oii);
							//echo "<br>informa dados ".$oiii;

							//echo '$powg';
							//$tmpmail = "AND  ( mem.profil = '6' OR SU.nu_seq_usuario = '".$powg."') " ;
							$tmpmail = "AND (SU.nu_seq_usuario='" . $powg . "' OR MEM.PROFIL ='6') ";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							//$usermail->openUserpro($tmpmail);
							$contmail = count($usermail->mem_id);

							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								$envimail->enviar('Demanda Em Analise', ' Demanda numero ' . $id . ' - ' . $pn . '  <br>neste momento está sendo analisada pelo(a) analista de relacionamento ' . $user_analista->usu_name[0] . '', $usermail->mem_email_work[$um]);
								$oii = $gera->insert($dateheure1 . " EXECUTADO POR:" . $nameSession . ",  ENVIADO EMAIL PARA :" . $usermail->mem_email_work[$um] . ".<br><br>", $oi);

								unset ($envimail);
								unset ($oii);
							}
							//GERA REFERENCIA
							$gera->referencia($dateh, '1', $id, 'Em Analise', $oi);

						}
						//fim envia informação em analise

						//envia validado pelo relacionamento
						if ($st == 4) {
							
							//$tmpmail = " AND  mem.profil = '6' or mem.id IN('".$powg."','".$hcfab."') " ;
							$oi = $gera->gera($dat, $hor);
					

							$tmpmail = " AND  ( mem.profil = '6' OR mem.profil = '10'  ) ";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							$contmail = count($usermail->mem_id);
							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								$envimail->enviar('Validado pelo Relacionamento', 'Analista de Relacionamento ' . $user_analista->usu_name[0] . ' finalizou Documento de Escopo da demanda  ' . $id . ' - ' . $pn . ',  <br>O gestor neste momento aguarda definição de prazos. <br>', $usermail->mem_email_work[$um]);
								$oii = $gera->insert($dateheure1 . " EXECUTADO POR:" . $nameSession . ",  ENVIADO EMAIL PARA :" . $usermail->mem_email_work[$um] . ".<br><br>", $oi);

								unset($envimail);
								unset($oii);
							}

							//GERA REFERENCIA
							$gera->referencia($dateh, '1', $id, 'Validado pelo Relacionamento', $oi);

							//INI AÇÃO
							if ($profilSession == 6) {
								$pessoa = "COORDENADOR";
							} else
								if ($profilSession == 7) {
									$pessoa = "ANALISTA";
								}

							$dateheure2 = invert_data($dateh) . " " . $hora . $minu;
							$acao = new arquivo();
							$faz = $acao->gera($dat, $hor . date('B') . "vt");
							$fazz = $acao->insert($dateheure2 . " EXECUTADO POR " . $pessoa . ": " . $nameSession . " <br>AÇÃO : Validado pelo Relacionamento  - GESTOR DA DEMANDA ATUAL  :" . $user_gest->usu_name[0] . " .<br><br>", $faz);
							$acao->referencia($dateh, '3', $id, 'Validado pelo Relacionamento', $faz);
							unset($fazz);
							unset($faz);
							unset($acao);
							//FIM AÇÃO

						}
						//fim validado pelo relacionamento

						//envia Aceito pelo cliente
						if ($st == 8) {
							//echo '$powg';
							//$tmpmail = "AND mem.profil = '6' or mem.id IN('".$powg."','".$hcfab."') " ;
							$tmpmail = " AND ( mem.profil = '6' OR mem.profil = '10' OR SU.nu_seq_usuario IN('" . $powg . "') )";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							$contmail = count($usermail->mem_id);
							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								$envimail->enviar('Confirmação do Aceite realizado pelo Cliente', 'A demanda  ' . $id . ' - ' . $pn . ',  <br>Foi Aceita. <br>', $usermail->mem_email_work[$um]);
								unset ($envimail);
							}
						}
						//envia Aceito pelo cliente

						//envia demanda Suspensa
						if ($st == 2) {
							
							//$tmpmail = "AND mem.profil = '6' or mem.id IN('".$powg."','".$hcfab."') " ;
							$tmpmail = "AND ( mem.profil = '6' OR mem.profil = '10' OR  SU.nu_seq_usuario IN('" . $powg . "') )";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							$contmail = count($usermail->mem_id);
							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								$envimail->enviar('Demanda Suspensa', 'A demanda ' . $id . ' - ' . $pn . ',  <br>Foi suspensa temporariamente pelo Gestor - ' . $user_gest->usu_name[0] . ' . <br>', $usermail->mem_email_work[$um]);
								unset ($envimail);
							}

							//INI AÇÃO
							if ($profilSession == 6) {
								$pessoa = "COORDENADOR";
							} else
								if ($profilSession == 7) {
									$pessoa = "ANALISTA";
								}

							$dateheure2 = invert_data($dateh) . " " . $hora . $minu;
							$acao = new arquivo();
							$faz = $acao->gera($dat, $hor . date('B') . "vt");
							$fazz = $acao->insert($dateheure2 . " EXECUTADO POR " . $pessoa . ": " . $nameSession . " <br>AÇÃO : Demanda Suspensa  - GESTOR DA DEMANDA ATUAL  :" . $user_gest->usu_name[0] . " .<br><br>", $faz);
							$acao->referencia($dateh, '3', $id, 'Demanda Suspensa por ' . $pessoa, $faz);
							unset($fazz);
							unset($faz);
							unset($acao);
							//FIM AÇÃO

						}
						//envia demanda Suspensa

						//envia demanda Cancelada
						if ($st == 11) {
							//echo '$powg';
							//$tmpmail = "AND mem.profil = '6' or mem.profil = '10'   " ;
							$tmpmail = "AND ( mem.profil = '6' OR mem.profil = '10' ) ";
							$usermail = new request();
							$usermail->openMembers($tmpmail);
							$contmail = count($usermail->mem_id);
							for ($um = 0; $um < $contmail; $um++) {
								//$enviar = "true";
								$envimail = new email();
								$envimail->enviar('Demanda Cancelada', 'A demanda ' . $id . ' - ' . $pn . ',  <br>Foi cancelada definitivamente pelo Gestor -  ' . $user_gest->usu_name[0] . ' . <br>', $usermail->mem_email_work[$um]);
								unset ($envimail);
							}

							//INI AÇÃO
							if ($profilSession == 6) {
								$pessoa = "COORDENADOR";
							} else
								if ($profilSession == 7) {
									$pessoa = "ANALISTA";
								}

							$dateheure2 = invert_data($dateh) . " " . $hora . $minu;
							$acao = new arquivo();
							$faz = $acao->gera($dat, $hor . date('B') . "vt");
							$fazz = $acao->insert($dateheure2 . " EXECUTADO POR " . $pessoa . ": " . $nameSession . " <br>AÇÃO : Demanda Cancelada  - GESTOR DA DEMANDA ATUAL  :" . $user_gest->usu_name[0] . " .<br><br>", $faz);
							$acao->referencia($dateh, '3', $id, 'Demanda Cancelada por ' . $pessoa, $faz);
							unset ($fazz);
							unset ($faz);
							unset ($acao);
							//FIM AÇÃO

						}
						//envia demanda Cancelada

					}
					if ($profilSession == 10) {
						$tmpquery = "UPDATE " . $tableCollab["projects"] . " SET id_ger_pro='$gpro' WHERE id = '$id'";
						connectSql("$tmpquery");

						//-----INFORMAÇÕES DO PROJETO----------//
						$tmpqq = " WHERE pro.id = '$id'";
						$lProject = new request();
						$lProject->openProjects($tmpqq);
						$nameprojeto = $lProject->pro_name[0];
						//-------------------------------------//					

						//retira demais gerente de projeto.
						$tmpquery = " WHERE tea.project = '$id' AND mem.profil = '1' ";
						$amClient = new request();
						$amClient->openTeams($tmpquery);
						$CamClient = count($amClient->tea_id);

						for ($i = 0; $i < $CamClient; $i++) {
							$tmpquery1 = "DELETE FROM sgd_fnde.teams WHERE project='$id' AND member='" . $amClient->tea_member[$i] . "'";
							connectSql("$tmpquery1");
							//exit;
						}

						$tmpmver = "WHERE tea.project ='$id' and tea.member= '" . $gpro . "' ";
						$verrequest = new request();
						$verrequest->openTeams($tmpmver);
						$countver = count($verrequest->tea_id);
						if ($countver < 1) {

							if (!$gpro == "" && $gpro > 0) {
								$tmptems = "INSERT INTO " . $tableCollab["teams"] . "(project,member,published ,authorized) VALUES('$id','$gpro','1','0')";
								connectSql("$tmptems");
								//Atribui a gerente de projeto

								//GERA LOG
								$gera = new arquivo();
								$dat = date('Ymd');
								$hor = date('Hi');

								$dateh = date('Y-m-d');
								$hora = date("H") - 3;
								$minu = date(':i');
								$dateheure1 = invert_data($dateh) . " " . $hora . $minu;
								$oi = $gera->gera($dat, $hor);

								//ini captura gerente de projeto

								$tmpmail = " AND SU.nu_seq_usuario ='" . $gpro . "' ";
								$user_gepro = new request();
								$user_gepro->openMembers($tmpmail);
								$contGpro = count($user_gepro->mem_id);
								//fim captura gerente de projeto

								//echo '$powg';
								//$tmpmail = " AND ( mem.profil = '6' OR mem.id ='".$gpro."' )" ;
								$tmpmail = " AND  SU.nu_seq_usuario ='" . $gpro . "' ";
								$usermail = new request();
								$usermail->openMembers($tmpmail);
								$contmail = count($usermail->mem_id);
								for ($um = 0; $um < $contmail; $um++) {
									//$enviar = "true";
									$envimail = new email();
									$envimail->enviar('Demanda atribuida pelo Coordenador da Fabrica', 'Coordenador da Fabrica atribui demanda  ' . $id . ' - ' . $nameprojeto . ',  <br>Para Gerente de projeto: ' . $user_gepro->mem_name[0] . ' .<br>', $usermail->mem_email_work[$um]);
									$oii = $gera->insert($dateheure1 . " EXECUTADO POR:" . $nameSession . ", ENVIADO EMAIL PARA :" . $usermail->mem_email_work[$um] . ".<br><br>", $oi);
									unset ($oii);
									unset ($envimail);

								}
								//GERA REFERENCIA
								$gera->referencia($dateh, '1', $id, 'Atribuida pelo Coordenador da Fabrica', $oi);

								//Atribui a gerente de projeto

							}
						}

					}

				}
				//$tmpqueryesc = "UPDATE ".$tableCollab["ata_reuniao"]." SET produto='$text_esc_titu' WHERE id_projeto = '$id'";
				//connectSql("$tmpqueryesc");
				/*echo '<script>alert("update");</script>'; */
				/*echo '<script>alert("ok");</script>'; */
			}

			//Definiçao de escopo
			//echo "--------".$mosindent;
			if ($mosindent == 1) {

				$tmpanexor = "UPDATE " . $tableCollab["ata_reuniao"] . " SET produto='$text_esc_titu',cliente='$text_esc_cli',situacao='$text_esc_desc',solicita_cliente='$text_esc_soli',justificativa='$text_esc_just',beneficio='$text_esc_ben',sistem_envovido='$text_esc_sisenv',tecnologias='$text_esc_tece',modelo_negocio='$text_esc_modn',area_envolvida='$text_esc_aneg',cenario='$text_esc_cdev',riscos='$text_esc_renv',lancamento='$text_esc_lanp',homologacao='$text_esc_hom',conograma='$text_esc_cono',suporte='$text_esc_supor',treinamento='$rtreino',tipo_treino='$rtreinot',manual='$rmanual',tipo_manual='$rmanualt',conclusao='$text_esc_concl' WHERE id_projeto = '$id'";
				connectSql("$tmpanexor");

			}

			if ($enableInvoicing == "true") {
				//$tmpquery3 = "UPDATE ".$tableCollab["invoices"]." SET active='$invoicing' WHERE project = '$id'";
				//connectSql($tmpquery3);
			}

			//if mantis bug tracker enabled
			if ($enableMantis == "true") {
				// call mantis function to copy project
				//include("../mantis/proj_update.php");
			}
			headerFunction("../projects/viewproject.php?id=$id&msg=update&" . session_name() . "=" . session_id());
			exit;
		}
	}

	//set value in form
	$pn = $projectDetail->pro_name[0];
	$d = $projectDetail->pro_description[0];
	$url_dev = $projectDetail->pro_url_dev[0];
	$url_prod = $projectDetail->pro_url_prod[0];
	$hourly_rate = $projectDetail->pro_hourly_rate[0];
	$invoicing = $projectDetail->pro_invoicing[0];
	$idStatus = $projectDetail->pro_status[0];
	$idPriority = $projectDetail->pro_priority[0];
	$org_id = $projectDetail->pro_org_id[0];
	$id_tipodemanda = $projectDetail->pro_t_demada[0];
	
}

//case add project
if ($id == "") {
	if ($profilSession != 0 && $profilSession != 1 && $profilSession != 6) {
		headerFunction("../projects/listprojects.php?" . session_name() . "=" . session_id());
		exit;
	}

	//set organization if add project action done from clientdetail
	if ($organization != "") {
		$projectDetail->pro_org_id[0] = "$organization";
	}

	//set default values
	$projectDetail->pro_mem_id[0] = "$idSession";
	$projectDetail->pro_priority[0] = "3";

	$projectDetail->pro_status[0] = "2";
	$projectDetail->pro_upload_max[0] = $maxFileSize;

	//case add project
	if ($action == "add") {
		//replace quotes by html code in name and description
		$pn = convertData($pn);
		$d = convertData($d);

		if ($invoicing == "" || $clod == "1") {
			$invoicing = "0";
		}

		if ($hourly_rate == "") {
			$hourly_rate = "0.00";
		}

		//insert into projects and teams (with last id project)
		//$tmpquery1 = "INSERT INTO ".$tableCollab["projects"]."(name,priority,description,owner,organization,status,created,published,upload_max,url_dev,url_prod,phase_set,invoicing,hourly_rate) VALUES('$pn','$pr','$d','$pown','$clod','$st','$dateheure','1','$up','$url_dev','$url_prod','$thisPhase','$invoicing','$hourly_rate')";
		//connectSql("$tmpquery1");
		//$tmpquery = $tableCollab["projects"];
		//last_id($tmpquery);
		//$num = $lastId[0];
		//unset($lastId);

		

		//$tmpquery2 = "."(project,member,published,authorized) VALUES('$num','$pown','1','0')";
		//connectSql("$tmpquery2");

		//if CVS repository enabled
		if ($enable_cvs == "true") {
			//$user_query = "AND mem.id = '$pown'";
			//$cvsUser = new request();
			//$cvsUser->openMembers($user_query);
			//cvs_add_repository($cvsUser->mem_login[0], $cvsUser->mem_password[0], $num);
		}

		//create project folder if filemanagement = true
		if ($fileManagement == "true") {
			//createDir("files/$num");
		}

		if ($htaccessAuth == "true") {
			$content =<<<STAMP
AuthName "$setTitle"
AuthType Basic
Require valid-user
AuthUserFile $fullPath/files/$num/.htpasswd
STAMP;

		}

		//if mantis bug tracker enabled
		if ($enableMantis == "true") {
			// call mantis function to copy project
			//include("../mantis/proj_add.php");
		}

		//create phase structure if enable phase was selected as true
		if ($thisPhase != "0") {
			$comptThisPhase = count($phaseArraySets[$thisPhase]);

			for ($i = 0; $i < $comptThisPhase; $i++) {
				$tmpquery = "INSERT INTO " . $tableCollab["phases"] . "(project_id,order_num,status,name) VALUES('$num','$i','0','" . $phaseArraySets[$thisPhase][$i] . "')";
				//connectSql("$tmpquery");
			}
		}

		headerFunction("../projects/viewproject.php?id=$num&msg=add&" . session_name() . "=" . session_id());
	}
}

//$bodyCommand = "onLoad='document.epDForm.pn'";

$bodyCommand = "";

include ('../themes/' . THEME . '/header.php');

echo '<div align=\"right\"><table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
<tr>
<td width="645">';
$blockPage = new block();
$blockPage->openBreadcrumbs();
$blockPage->itemBreadcrumbs($blockPage->buildLink("../projects/listprojects.php?", $strings["projects"], in));

//case add project

if ($id == "") {
	$blockPage->itemBreadcrumbs($strings["add_project"]);
}

//case update or copy project
if ($id != "") {
	$blockPage->itemBreadcrumbs($blockPage->buildLink("../projects/viewproject.php?id=" . $projectDetail->pro_id[0], $projectDetail->pro_name[0], in));

	if ($docopy == "true") {
		$blockPage->itemBreadcrumbs($strings["copy_project"]);
	} else {
		$blockPage->itemBreadcrumbs($strings["edit_project"]);
	}
}
$blockPage->closeBreadcrumbs();
echo '</td>';
echo "<td width=\"47\" align=\"right\">" . $blockPage->buildLink("../projects/listprojects.php?", $strings["home"], in) . "</td>";
echo '<td width="5">&nbsp;|</td>';
echo "<td width=\"68\" align=\"right\">";
if ($profilSession == 0 || $profilSession == 6 || $profilSession == 7 || $profilSession == 9) {
	echo "<a href=\"../calendar/viewcalendar.php?id=" . $projectDetail->pro_id[0] . "\">" . $strings["calendar"] . "</a>|";
}
echo "</td>";
echo '<td width="10"></td>
  </tr>
</table></div>';

if ($msg != "") {
	include ('../includes/messages.php');
	$blockPage->messagebox($msgLabel);
}

$block1 = new block();

//case add project
if ($id == "") {
	$block1->form = "epD";
	$block1->openForm("../projects/editproject.php?action=add&" . session_name() . "=" . session_id() . "#" . $block1->form . "Anchor");
}

//case update or copy project
if ($id != "") {
	$block1->form = "epD";
	$block1->openForm('../projects/editproject.php?id=' . $id . '&action=update&docopy=' . $docopy . '&' . session_name() . "=" . session_id() . "#" . $block1->form . "Anchor");
	echo "<input type='hidden' value='" . $projectDetail->pro_published[0] . "' name='projectPublished'>";
}

if ($error != "") {
	$block1->headingError($strings["errors"]);
	$block1->contentError($error);
}

//case add project
if ($id == "") {
	$block1->heading($strings["add_project"]);
}

//case update or copy project
if ($id != "") {
	if ($docopy == "true") {
		$block1->heading($strings["copy_project"] . " : " . $projectDetail->pro_name[0]);
	} else {
		$block1->heading($strings["edit_project"] . " : " . $projectDetail->pro_name[0]);
	}
}

// inicio indentificaçao da demanda 
if ($profilSession == 6 || $profilSession == 9) {
	$contro_indent = "";
	$contro_select = "";
	$contro_status = "";
	$contro_fase = "";
	$contro_faseselect = "";
	$contro_display = '';
} else {
	$contro_indent = "readonly=\"true\"";
	$contro_select = "disabled";
	$contro_status = "disabled";
	$contro_fase = "readonly=\"true\"";
	$contro_faseselect = "disabled";
	$contro_display = "style=\"display:none \"";

	if ($profilSession == 7) {
		$contro_status = "";
		$contro_indent = "";
		$contro_check = "";
		$contro_fase = "readonly=\"true\"";

	}
	if ($profilSession == 10 || $profilSession == 6 || $profilSession == 9) {
		$contro_campo = "";
	} else {

		$contro_campo = "disabled";
	}
	//cordenador de fabrica
	if ($profilSession == 10) {
		//$contro_status = "";
		//$contro_indent = "";
		//$contro_check = "";
		$contro_fase = "";
		$contro_faseselect = "";
		$contro_display = '';
	}

}

$blockz1 = new block();

$blockz1->heading("<a href=\"#\" onClick=\"verif('imgindent','mosindent','mindent','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgindent\" src=\"../themes/" . THEME . "/btn_subtrai.gif\" alt=\"\" border=\"0\"></strong></a>  " . $strings["my_demandas"]);

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

//Pega os sistemas 

$tmpquerys = " ORDER BY NOME ";
$listSistem = new request();

$listSistem->openSosistema($tmpquerys);
$comptListSistem = count($listSistem->sis_id);

//inicio gestor	
//$tmp_alluser = " ";
$tmp_alluser = " AND SG.NO_GRUPO IN('sgd_gestor') ";

$all_users = new request();
$all_users->openSousuario($tmp_alluser);
$contAlluser = count($all_users->so_id);

//fim gestor	 

//gestor da demanda 
$sel_member = new request();
$tmquery_member = "where mem.id =" . fixInt($projectDetail->pro_owner[0]);
$sel_member->openMembers($tmquery_member);
$nome_gestor = $sel_member->mem_name[0];
$id_gestor = $sel_member->mem_id[0];
//----------$projectDetail->pro_owner[0];------------------
//-----------inicio ger rel------------------

$sel_grel = new request();
$tmquery_rel = " where mem.profil =" . fixInt("6");
$sel_grel->openMembers($tmquery_rel);
$contGrel = count($sel_grel->mem_id);

if ($sel_grel->mem_name[0] != "") {
	$nome_g_rel = $sel_grel->mem_name[0];
} else {
	$nome_g_rel = "Em Definição...";
}

//-----------fim ger rel---------------------

//-----------inicio ger pro------------------

if ($projectDetail->pro_t_demada[0] == 3) {
	$tmquery_gpro = " AND SG.NO_GRUPO='sgd_user_serv' ";
	$control_campo = $contro_status;
} else {
	$tmquery_gpro = " AND SG.NO_GRUPO='sgd_gerente_projeto' ";
	$control_campo = $contro_campo;
}
$sel_gepro = new request();
//$sel_gepro->openAplicacao($tmquery_gpro);
$sel_gepro->openSousuario($tmquery_gpro);
$contGepro = count($sel_gepro->so_id);
if ($sel_gepro->so_login[0] != "") {
	$nome_g_pro = $sel_gepro->so_login[0];
} else {
	$nome_g_pro = "Em Definição...";
}

//-----------fim ger pro---------------------

//-----------inicio organization------------------
$sel_georg = new request();
//$tmquery_gpro = " where mem.id =".fixInt($projectDetail->pro_mem_idgpro[0]);
$tm = "  ";
$sel_georg->openOrganizations($tm);
$sel_georgcont = count($sel_georg->org_id);


//-----------fim organization---------------------

//-----------inicio coodra------------------

$sel_corra = new request();
$tmquery_corra = " where mem.profil =" . fixInt("9");
$sel_corra->openMembers($tmquery_corra);
$contCorra = count($sel_corra->mem_id);
if ($sel_corra->mem_name[0] != "") {
	$nome_corra = $sel_corra->mem_name[0];
} else {
	$nome_corra = "Em Definição...";
}
//-----------fim coodra---------------------


$sel_analita = new request();
$tmquery_analita = " AND SG.NO_GRUPO='sgd_analista_relat' ";
$sel_analita->openSousuario($tmquery_analita);
$contAnalita = count($sel_analita->so_id);

if ($sel_analita->so_login[0] != "") {
	$nome_analita = $sel_analita->so_login[0];
} else {
	$nome_analita = "Em Definição...";
}

//-----------fim fabrica--------------------- 

//-------------Cordenação----------------------
$sel_cordena = new request();
$tmquery_cordena = " AND SG.NO_GRUPO='sgd_coordenador_relacionamento' ";
$sel_cordena->openSousuario($tmquery_cordena);
$contCordena = count($sel_cordena->so_id);

if ($sel_cordena->so_login[0] != "") {
	$nome_cordena = $sel_cordena->so_login[0];
} else {
	$nome_cordena = "Em Definição...";
}

//-------------Cordenação----------------------- 


if ($id_tipodemanda != 3) {
	$gerencia = $strings["project_manager_permissions"];
	$combo_text = "Selecione Gerente de projeto";

} else {
	$gerencia = $strings["project_manager_reponsavel"];
	$combo_text = "Selecione Responsável";
}

if (!($i % 2)) {
	$class = "odd";
	$highlightOff = $blockz1->oddColor;
} else {
	$class = "even";
	$highlightOff = $blockz1->evenColor;
}

echo "	<table id='mindent' width='99%' cellpadding='0' cellspacing='0' border='0' style=\"display:''\">
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["num_demanda"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<strong>" . $projectDetail->pro_id[0] . "</strong></td>
			</tr>";
			
if ($id_tipodemanda != 3) {

	echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
					<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["sistema"] . " :</th>
					<td align='right'>&nbsp;</td><td >&nbsp;<select " . $contro_status . "  id=\"select_name\" name=\"select_name\" style=\"width:190px; height:15px\">
	    <option value=\"0\" >Selecione o Sistema</option>";
	//<option value=\"0\">".$tipo_demanda."</option>";

	for ($i = 0; $i < $comptListSistem; $i++) {
		echo "<option value=\"" . $listSistem->sis_id[$i] . "\" ";
		if ($listSistem->sis_id[$i] == $projectDetail->pro_sistema[0]) {
			echo 'selected';
		}
		echo " >" . $listSistem->sis_nome[$i] . "</option>";
	}

	echo "</select></td>	</tr>";
}
echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["t_demanda"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<input name=\"pn\" type=\"text\" " . $contro_status . " size=\"40\" maxlength=\"50\" value=\"" . $projectDetail->pro_name[0] . "\" style=\"width:190px\"></td>
			</tr>
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["status"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"st\" " . $contro_status . " style=\"width:190px; height:15px\" onChange=\"dajanela('criadpedente.php?proj=" . $projectDetail->pro_id[0] . "&tipo=this.value&idfase=" . $idfase . "',this.value,'250','150',this.value);\">";
echo "<option value=\"3\" ";
if ($idStatus == 3) {
	echo 'selected';
}
echo ">Aberto</option>";
echo "<option value=\"1\" ";
if ($idStatus == 1) {
	echo 'selected';
}
echo ">Em Analise</option>";
echo "<option value=\"4\" ";
if ($idStatus == 4) {
	echo 'selected';
}
echo ">Validado pelo relacionamento</option>";
echo "<option value=\"5\" ";
if ($idStatus == 5) {
	echo 'selected';
}
echo ">Validado TI</option>";
echo "<option value=\"0\" ";
if ($idStatus == 0) {
	echo 'selected';
}
echo ">Validado pelo Cliente</option>";
echo "<option value=\"6\" ";
if ($idStatus == 6) {
	echo 'selected';
}
echo ">Em Andamento</option>";
echo "<option value=\"7\" ";
if ($idStatus == 7) {
	echo 'selected';
}
echo ">Aguardando Homologação</option>";
echo "<option value=\"9\" ";
if ($idStatus == 9) {
	echo 'selected';
}
echo ">Em Homologação</option>";
echo "<option value=\"8\" ";
if ($idStatus == 8) {
	echo 'selected';
}
echo ">Aceito pelo Cliente</option>";
echo "<option value=\"10\" ";
if ($idStatus == 10) {
	echo 'selected';
}
echo ">Concluído</option>";
echo "<option value=\"12\" ";
if ($idStatus == 12) {
	echo 'selected';
}
echo ">Pendente</option>";
echo "<option value=\"2\" ";
if ($idStatus == 2) {
	echo 'selected';
}
echo ">Suspensa</option>";
echo "<option value=\"11\" ";
if ($idStatus == 11) {
	echo 'selected';
}
echo ">Cancelada</option>";

//$status[$idStatus]
echo "</select>&nbsp;";
if (($idStatus == 11 || $idStatus == 2 || $idStatus == 12) && ($projectDetail->pro_description[0] != "")) {
	echo "<img src=\"../themes/default/exclamacao_" . $idStatus . ".gif\" width=\"12\" height=\"12\" title=\"Justificativa \" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janelada('abredpedente.php?proj=" . $projectDetail->pro_id[0] . "','pedente','250','160');\">";
}
echo "</td>
			
			</tr>
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;" . $strings["tipo_demanda"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"tipodemanda\" " . $contro_status . " style=\"width:190px; height:15px\">";
echo "<option value=\"0\" ";
if ($id_tipodemanda == 0) {
	echo 'selected';
}
echo ">Novo Sistema</option>";
echo "<option value=\"1\" ";
if ($id_tipodemanda == 1) {
	echo 'selected';
}
echo ">Corretiva</option>";
echo "<option value=\"2\" ";
if ($id_tipodemanda == 2) {
	echo 'selected';
}
echo ">Evolutiva</option>";
echo "<option value=\"3\" ";
if ($id_tipodemanda == 3) {
	echo 'selected';
}
echo ">Serviços</option>";
//echo "<option value=\"0\" ><img src=\"../themes/".THEME."/gfx_priority/".$idPriority.".gif\" alt=\"\">&nbsp; $priority[$idPriority]</option>";
echo " </select></td></tr>";
//
if ($id_tipodemanda == 3) {
	echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
					<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["area_responsavel"] . " :</th>
					<td align='right'>&nbsp;</td><td >&nbsp;<select " . $contro_status . "  id=\"select_servico\" name=\"select_servico\" style=\"width:190px; height:15px\">
					<option value=\"0\" >Selecione a Área</option>";

	for ($i = 5; $i < 9; $i++) {
		echo "<option value=\"" . $i . "\" ";
		if ($i == $projectDetail->pro_phase_set[0]) {
			echo 'selected';
		}
		echo " >" . $tipo_servico[$i] . "</option>";
	}

	echo "</select></td></tr>";
}
//

echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' valign='top' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["date_open"] . " : </th>
				<td align='right'>&nbsp;</td><td >&nbsp;" . nl2br(invert_data($projectDetail->pro_created[0], $timezoneSession)) . "</td>
			</tr>
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;" . $strings["priority"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"pr\" " . $contro_select . " style=\"width:190px; height:15px\">";
echo "<option value=\"2\" ";
if ($idPriority == 2) {
	echo 'selected';
}
echo ">Baixa</option>";
echo "<option value=\"3\" ";
if ($idPriority == 3) {
	echo 'selected';
}
echo ">Media</option>";
echo "<option value=\"5\" ";
if ($idPriority == 5) {
	echo 'selected';
}
echo ">Alta</option>";
//echo "<option value=\"0\" ><img src=\"../themes/".THEME."/gfx_priority/".$idPriority.".gif\" alt=\"\">&nbsp; $priority[$idPriority]</option>";
echo " </select></td></tr>";

//ESCALA
echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
			<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp;&nbsp;" . $strings["escala"] . " :</th>
			<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"select_scala\" " . $contro_status . " style=\"width:190px; height:15px\">";
echo "<option value=\"0\">----->Selecione a Escala<-----</option>";
echo "<option value=\"5\" ";
if ($url_dev == 5) {
	echo 'selected';
}
echo ">Presidência</option>";
echo "<option value=\"4\" ";
if ($url_dev == 4) {
	echo 'selected';
}
echo ">Diretória</option>";
echo "<option value=\"3\" ";
if ($url_dev == 3) {
	echo 'selected';
}
echo ">Coordenação Geral</option>";
echo "<option value=\"2\" ";
if ($url_dev == 2) {
	echo 'selected';
}
echo ">Coordenação</option>";
echo "<option value=\"1\" ";
if ($url_dev == 1) {
	echo 'selected';
}
echo ">Divisão</option>";
//echo "<option value=\"0\" ><img src=\"../themes/".THEME."/gfx_priority/".$idPriority.".gif\" alt=\"\">&nbsp; $priority[$idPriority]</option>";
echo " </select></td>
			</tr>";
//

echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["uni_adm"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"clod\" " . $contro_status . " style=\"width:190px; height:15px\" onChange=\"updateorg(this.value,'editproject.php?id=" . $projectDetail->pro_id[0] . "');\">";
for ($n = 0; $n < $sel_georgcont; $n++) {
	//vazio
	if ($org == "") {
		echo "<option value=\"" . $sel_georg->org_id[$n] . "\" ";
		if ($projectDetail->pro_organization[0] == $sel_georg->org_id[$n]) {
			echo 'selected';
		}
		echo ">" . $sel_georg->org_name[$n] . "</option>";
	}
	//vazio
	if (!$org == "") {
		echo "<option value=\"" . $sel_georg->org_id[$n] . "\" ";
		if ($org == $sel_georg->org_id[$n]) {
			echo 'selected';
		}
		echo ">" . $sel_georg->org_name[$n] . "</option>";
	}
}
echo " </select>";
//echo "$priority[$idPriority] -- $org_id";
echo "</td>
			</tr>
			
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["nome_gestor"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select id='pown' name=\"pown\" " . $contro_status . " style=\"width:230px; height:15px\">";
echo "<option value=\"0\">----->Selecione Usuário<-----</option>";

if ($org == "") {
	//vazio
	//GESTOR DE PROJETO
	echo "<optgroup style='azimuth:center'  label=\"-----------GESTOR----------\" >";
	for ($g = 0; $g < $contAlluser; $g++) {
		if ($all_users->so_gnome[$g] == "sgd_gestor") {
			
			$tmpq = " and su.id = '" . $all_users->so_id[$g] . "' and suo.id = '" .$projectDetail->pro_organization[0]  . "'";
			$amUnidade = new request();
			$amUnidade->openLota($tmpq);
			$ContUnidade = count($amUnidade->lot_id);
			if ($ContUnidade > 0) {
				//if($projectDetail->pro_organization[0]==$all_users->apl_idunidade[$g]){	
				echo "<option value=\"" . $all_users->so_id[$g] . "\" ";
				if ($projectDetail->pro_owner[0] == $all_users->so_id[$g]) {
					echo 'selected';
				}
				echo ">" . $all_users->so_nome[$g] . "</option>";
			}
		}
		unset ($ContUnidade);
		unset ($amUnidade);
	} //FIM FOR
	echo "</optgroup>";
	//-----------------------------//
}
if ($org != "") {
	//cheio
	//GESTOR DE PROJETO
	echo "<optgroup style='azimuth:center'  label=\"-----------GESTOR----------\" >";
	for ($g1 = 0; $g1 < $contAlluser; $g1++) {
		if ($all_users->so_gnome[$g1] == "sgd_gestor" ) {
			//$tmpq = " and u.nu_seq_usuario = '".$all_users->so_id[$g1]."' and uo.nu_seq_interno_uorg = '".$org."'";
			$tmpq = " and su.id = '" . $all_users->so_id[$g1] . "' and suo.id = '" . $org . "'";
			
			$amUnidade = new request();
			$amUnidade->openLota($tmpq);
			$ContUnidade = count($amUnidade->lot_id);
			
			if ($ContUnidade > 0) {
				//if($org==$all_users->apl_idunidade[$g]){	
				echo "<option value=\"" . $all_users->so_id[$g1] . "\" ";
				if ($projectDetail->pro_owner[0] == $all_users->so_id[$g1]) {
					echo 'selected';
				}
				echo ">" . $all_users->so_nome[$g1] . "</option>";
			}
		}
		unset ($ContUnidade);
		unset ($amUnidade);
	} //FIM FOR
	echo "</optgroup>";

}
//-----------------------------//
//ANALISTA DE PROJETO
echo "<optgroup style='azimuth:center'  label=\"----------ANALISTA---------\" >";
for ($gg = 0; $gg < $contAnalita; $gg++) {
	if ($sel_analita->so_gnome[$gg] == "sgd_analista_relat") {
		echo "<option value=\"" . $sel_analita->so_id[$gg] . "\" ";
		if ($projectDetail->pro_owner[0] == $sel_analita->so_id[$gg]) {
			echo 'selected';
		}
		echo ">" . $sel_analita->so_nome[$gg] . "</option>";
	}
} //FIM FOR
echo "</optgroup>";
//-----------------------------//
//CORDENAÇÃO DE PROJETO
echo "<optgroup style='azimuth:center'  label=\"--------COORDENAÇÃO--------\" >";
for ($g3 = 0; $g3 < $contCordena; $g3++) {
	if ($sel_cordena->so_gnome[$g3] == "sgd_coordenador_relacionamento") {

		echo "<option value=\"" . $sel_cordena->so_id[$g3] . "\" ";
		if ($projectDetail->pro_owner[0] == $sel_cordena->so_id[$g3]) {
			echo 'selected';
		}
		echo ">" . $sel_cordena->so_nome[$g3] . "</option>";

	}
}
echo "</optgroup>";

echo " </select><input type=\"hidden\" name=\"powg\" value=\"" . $id_gestor . "\"></td>
				
			</tr>
			
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["coor_r_a"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select id='powncoo' name=\"powncoo\" " . $contro_select . " style=\"width:230px; height:15px\">";

echo "<option value=\"\" >" . strtoupper($string["cord_relacionamento"]) . "</option>";
echo " </select></td>
			</tr>
			
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["resp_relaciona"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select id=\"select5\" name=\"select5\" " . $contro_select . " style=\"width:230px; height:15px\">";

echo "<option value=\"\" >" . strtoupper($string["ger_relacionamento"]) . "</option>";

echo " </select></td>
			</tr>
			
			
			<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $strings["analista_relacionamento_permissions"] . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select name=\"select_an\" " . $contro_select . " style=\"width:230px; height:15px\">";
//analista relacionamento

echo "<option value=\"\" >Selecione Analista </option>";

for ($an = 0; $an < $contAnalita; $an++) {
	//echo "<option value=\"".$sel_analita->so_id[$an]."\" "; if($projectDetail->pro_men_analista[0] == $sel_analita->mem_id[$an]){ echo 'selected'; } echo ">".$sel_analita->mem_name[$an]."</option>";
	echo "<option value=\"" . $sel_analita->so_id[$an] . "\" ";
	if ($projectDetail->pro_men_analista[0] == $sel_analita->so_id[$an]) {
		echo 'selected';
	}
	echo ">" . $sel_analita->so_nome[$an] . "</option>";
}
echo " </select><input type=\"hidden\" name=\"select_analist\" value=\"" . $projectDetail->pro_men_analista[0] . "\"><input type=\"hidden\" name=\"select_cfab\" value=\"" . $sel_cfab->mem_id[0] . "\"></td>
			</tr>";

echo "<tr class='$class' onmouseover=\"this.style.backgroundColor='" . $blockz1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
				<th nowrap class='FormLabel' align='left'>&nbsp;&nbsp;&nbsp; " . $gerencia . " :</th>
				<td align='right'>&nbsp;</td><td >&nbsp;<select id=\"gpro\" name=\"gpro\" " . $control_campo . " style=\"width:230px; height:15px\">";

echo "<option value=\"\" >" . $combo_text . "</option>";
for ($gp = 0; $gp < $contGepro; $gp++) { //$projectDetail->pro_owner[0]

	echo "<option value=\"" . $sel_gepro->so_id[$gp] . "\" ";
	if ($projectDetail->pro_mem_idgpro[0] == $sel_gepro->so_id[$gp]) {
		echo 'selected';
	}
	echo ">" . $sel_gepro->so_nome[$gp] . "</option>";
}

echo " </select></td>
			</tr>";


echo "</table>";

$block_escopo = new block();


if (($projectDetail->pro_t_demada[0] == 2) || ($projectDetail->pro_t_demada[0] == 0) || ($projectDetail->pro_t_demada[0] == 3)) {
	$block_escopo->heading("<a href=\"#\" onClick=\"verif('imgescopo','mosescopo','mescop','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgescopo\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a>  " . $strings["def_escopo"]);
} else
	if ($projectDetail->pro_t_demada[0] == 1) {
		$block_escopo->heading("<a href=\"#\" onClick=\"verif('imgescopo','mosescopo','mescop','err');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgescopo\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a>  " . $strings["image_erro"]);
	}

$tmpqueryata = "WHERE ata.id_projeto='" . $projectDetail->pro_id[0] . "'";
$ataprojeto = new request();
$ataprojeto->openAta($tmpqueryata);
$variavel = count($ataprojeto->ata_id);

//$variavel = 1 ;
if ($variavel <= 0) {

	if (($projectDetail->pro_t_demada[0] == 0) || ($projectDetail->pro_t_demada[0] == 2) || ($projectDetail->pro_t_demada[0] == 3)) {

		echo "<table id='mescop' cellpadding='0' cellspacing='0' border='0' style=\"display:none\">";
		echo "<tr>
						<td align='right'>";
		echo "&nbsp;&nbsp;&nbsp;<a href='../projects/editproject.php?id=" . $projectDetail->pro_id[0] . "&docopy=false&addf=" . $projectDetail->pro_id[0] . "'><img  id=\"adm2\" src=\"../themes/" . THEME . "/btn_add_norm.gif\" alt=\"\" border=\"0\" onmouseover=\"trocaImg('btn_add_over.gif','adm2');\" onmouseout=\"trocaImg('btn_add_norm.gif','adm2');\" style=\"display:''\"></a>";
						
		echo "</td><td align='right'>&nbsp;<strong style=color:blue>Em Analise...</strong></td>
					  </tr>";
		echo "</table>";

	} else
		if ($projectDetail->pro_t_demada[0] == 1) {
			//informaçõa de erro 
			//inicio image de erro 
			$tmpco = " WHERE co.id_projeto = '" . $projectDetail->pro_id[0] . "'";
			$requestco = new request();
			$requestco->openCorretiva($tmpco);
			$countCo = count($requestco->co_id);
			//fim image de erro 
			if ($profilSession == 6 || $profilSession == 7) {

				echo "<a href='adderro.php?$transmitSid&project=" . $projectDetail->pro_id[0] . "'><img  id=\"err\" src=\"../themes/" . THEME . "/btn_add_norm.gif\" alt=\"Adicionar erros\" border=\"0\" onmouseover=\"trocaImg('btn_add_over.gif','err');\" onmouseout=\"trocaImg('btn_add_norm.gif','err');\" style=\"display:none\"></a>";

			}

			echo "<table id='mescop' cellspacing='0' width=\"99%\" border='0' cellpadding='3' cols='4'  bgcolor='#C4D3DB' style=\"display:none\">
							<tr align='left'>
								<th width='15%'></th>
								<th width='30%'>" . $strings["titulo"] . "</th>
								<th width='25%'></th>
								<th width='10%'>" . $strings["files"] . "</th>
							</tr>";
			for ($k = 0; $k < $countCo; $k++) {
				$b = $k;
				$a_som = $k % 2;
				if ($a_som > 0) {
					$class_som = 'odd';
				} else {
					$class_som = 'even';
				}
				$desc_som = "";
				//$desc_som = substr($requestsom->ata_arquivo[$k], 0,48);
				$detanha = "DETALHAMENTO: ";
				//".$requestatar->atar_id[$k]."/".++$b."".$requestatar->atar_data[$k]."".$requestsom->ata_arquivo[$k]."
				echo "<tr class='$class_som' onmouseover=\"this.style.backgroundColor='" . $block1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
										<td width='15%' ></td>
										<td width='30%'>" . $requestco->co_descricao[$k] . "</td>
										<td width='25%'></td>
										<td width='10%'>&nbsp;&nbsp;<a href=\"" . $requestco->co_erro[$k] . "\" target=\"_blank\" onMouseOut=\"window.status=''\"; onMouseOver=\"return window.status='Arquivo Informação de Erro'\"; title=\"Visualiza Informação de Erro\" ><img src=\"../themes/default/btn_edit_over.gif\" width=\"15\" height=\"15\" border=\"0\"></a>";
				if ($profilSession == 7 || $profilSession == 6) {
					echo "<img id='imgrr' src=\"../themes/default/btn_remove_norm.gif\" width=\"15\" height=\"15\" border=\"0\" onMouseOut=\"return window.status=''\";\"imgrr.src='../themes/default/btn_remove_norm.gif'\"; onMouseOver=\"return window.status='Remover Informação de Erro'\";\"imgrr.src='../themes/default/btn_remove_over.gif'\"; title=\"Remover Informação de Erro\"; style=\"cursor:hand\" onClick=\"window.location.href='editproject.php?evento=true&idvalor=" . $projectDetail->pro_id[0] . "&iderro=" . $requestco->co_id[$k] . "';\">";
				}

				echo "</td></tr>";
			}

		
			echo "</table>";

		}

} else {

	//include "showsubata.php";

	echo "<table id=\"mescop\" align='center' width=\"735\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"display: none \">
	  <tr>
	    <td>";

	echo '<table width="735" border="1" cellpadding="0" cellspacing="0" bordercolor="#CCCCCC">';

	echo "<tr>
	        <td valign=\"top\"><strong>Data de Realização: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"text_esc_dat\" type=\"text\" size=\"10\" maxlength=\"10\" readonly=\"true\" value=\"" . invert_data($ataprojeto->ata_data[0]) . "\">";
	echo '</strong></td>
	      </tr>
	    </table><br>';
	echo ' <table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	           <td height="2" bgcolor="#F2F2F2"></td>
			  <td height="15" bgcolor="#F2F2F2"><strong>INFORME O ANEXO</strong></td>
	          <td height="15" bgcolor="#F2F2F2"></td>
	           <td width="25" height="15" bgcolor="#F2F2F2"></td>';
	if ($profilSession == 0 || $profilSession == 6 || $profilSession == 9 || $profilSession == 7) {
		echo "<td width=\"13\" height=\"15\" bgcolor=\"#F2F2F2\"><a  onClick=\"janela('anexo.php?idpro=" . $projectDetail->pro_id[0] . "&req=editproject.php&idd=" . $ataprojeto->ata_id[0] . "','anexo','400','200');\" href=\"#\">Adicionar</td>";
	} else {
		echo "<td width=\"13\" height=\"15\" bgcolor=\"#F2F2F2\"></td>";
	}
	echo "</tr>";
	
	//inicio ata reuniao 

	$tmpimpatar = " WHERE atn.id_ata = '" . $ataprojeto->ata_id[0] . "'";
	$requestatar = new request();
	$requestatar->openAtaanexo($tmpimpatar);
	//fim ata reuniao

	$block_mudanca = new block();

	echo "<tr align='left'>
						<th width='2%'></th>
						<th width='15%'>" . $strings["id"] . "</th>
						<th width='30%'>" . $strings["titulo"] . "</th>
						<th width='25%'>" . $strings["dt_abertura"] . "</th>
						<th width='10%'>" . $strings["files"] . "</th>
					</tr>";
	$cont_som = 0;
	for ($k = 0; $k < count($requestatar->atan_id); $k++) {
		$b = $k;
		$a_som = $k % 2;
		if ($a_som > 0) {
			$class_som = 'odd';
		} else {
			$class_som = 'even';
		}
		$desc_som = "";
		//$desc_som = substr($requestsom->ata_arquivo[$k], 0,48);
		$detanha = "DETALHAMENTO: ";
		echo "<tr class='$class_som' onmouseover=\"this.style.backgroundColor='" . $block1->highlightOn . "'\" onmouseout=\"this.style.backgroundColor='" . $highlightOff . "'\">
								<td width='2%' ></td>
								<td width='15%' >" . $requestatar->atan_id[$k] . "/" . ++ $b . "</td>
								<td width='30%'>" . $requestatar->atan_titulo[$k] . "</td>
								<td width='25%'>" . invert_data($requestatar->atan_data[$k]) . "</td>
								<td width='10%'>&nbsp;&nbsp;<a href=\"" . $requestatar->atan_documento[$k] . "\" target=\"_blank\"><img id='imgrr2' src=\"../themes/default/btn_edit_norm.gif\" onMouseOut=\"imgrr2.src='../themes/default/btn_edit_norm.gif'\"; onMouseOver=\"imgrr2.src='../themes/default/btn_edit_over.gif'\"; width=\"15\" height=\"15\" title=\"Visualizar Arquivo de Escopo\"; border=\"0\"></a>" . $requestsom->ata_arquivo[$k] . "&nbsp;&nbsp;";
		if ($profilSession == 6 || $profilSession == 7) {
			echo "<img id='imgrr' src=\"../themes/default/btn_remove_norm.gif\" width=\"15\" height=\"15\" border=\"0\" onMouseOut=\"imgrr.src='../themes/default/btn_remove_norm.gif'\"; onMouseOver=\"imgrr.src='../themes/default/btn_remove_over.gif'\"; title=\"Remover Arquivo de Escopo\"; style=\"cursor:hand\" onClick=\"window.location.href='editproject.php?evento=true&idvalor=" . $projectDetail->pro_id[0] . "&idscopo=" . $requestatar->atan_id[$k] . "';\">";
		}
		echo "</td>
						  </tr>";
	}
	//echo "</table>";
	//fim ata reuniao

	//echo '<td bgcolor="#FFFFFF">oiioioi&nbsp;</td>';
	//echo '</tr>';
	echo '</table><br>';

	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>INFORMAÇÕES DO GESTOR</strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_cli\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_cliente[0] . "</textarea></td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>DESCRI&Ccedil;&Atilde;O DA SITUA&Ccedil;&Atilde;O ATUAL </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea id=\"text_esc_desc\" " . $contro_indent . " name=\"text_esc_desc\" cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_situacao[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>SOLICITA&Ccedil;&Atilde;O DO CLIENTE </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_soli\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_sol_cliente[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>JUSTIFICATIVA DA SOLICITA&Ccedil;&Atilde;O </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo " <td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_just\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_justificativa[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>BENEFÍCIOS </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea id=\"text_esc_ben\" " . $contro_indent . " name=\"text_esc_ben\" cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_beneficio[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>SISTEMAS ENVOLVIDO</strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_sisenv\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_sistem_envol[0] . "</textarea> </td>";
	echo ' <td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>T&Eacute;CNOLOGIAS ENVOLVIDAS: </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_tece\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_tecnologia[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>ENTIDADES EXTERNAS ENVOLVIDAS NO DESENVOLVIMENTO</strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_modn\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_mod_negocio[0] . "</textarea></td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>&Aacute;REA DE NEG&Oacute;CIO ENVOLVIDAS</strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_aneg\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_area_envol[0] . "</textarea></td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>CENÁRIOS DE POSSÍVEIS SOLUÇÕES PARA O DESENVOLVIMENTO </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_cdev\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_cenario[0] . "</textarea></td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>RISCOS EXTERNOS ENVOLVIDOS </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_renv\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_risco[0] . "</textarea></td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>LAN&Ccedil;AMENTO DO PRODUTO </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_lanp\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_lancamento[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>CRITÉRIOS DE HOMOLOGAÇÃO</strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_hom\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_homologa[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>CRONOGRAMA SUGERIDO PELO CLIENTE </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea id=\"text_esc_cono\" " . $contro_indent . " name=\"text_esc_cono\" cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_cronograma[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>SUPORTE DE TI </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_supor\" " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_suporte[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>NECESSIDADE DE TREINAMENTO E/OU CONFEC&Ccedil;&Atilde;O DE MATERIAL </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2"></td>
	        </tr>
	        <tr>
	          <td width="10" height="20" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" height=\"20\" bgcolor=\"#FFFFFF\">
			  <p>Necessidade de Treinamento: 
	   Sim";

	echo "<input name=\"rtreino\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"1\" ";
	if ($ataprojeto->ata_treinamento[0] == 1) {
		echo 'checked';
	}
	echo " >
	   N&atilde;o
	   <input name=\"rtreino\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"0\" ";
	if ($ataprojeto->ata_treinamento[0] == 0) {
		echo 'checked';
	}
	echo "><br>
	   Virtual 
	   <input name=\"rtreinot\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"0\" ";
	if ($ataprojeto->ata_tipo_treino[0] == 0) {
		echo 'checked';
	}
	echo "> 
	| Presencial 
	<input name=\"rtreinot\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"1\" ";
	if ($ataprojeto->ata_tipo_treino[0] == 1) {
		echo 'checked';
	}
	echo ">  
	</p>
	<p>Necessidade de Confec&ccedil;&atilde;o de Material: 
	   Sim 
	   <input name=\"rmanual\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"1\" ";
	if ($ataprojeto->ata_manual[0] == 1) {
		echo 'checked';
	}
	echo ">
	   N&atilde;o
	   <input name=\"rmanual\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"0\" ";
	if ($ataprojeto->ata_manual[0] == 0) {
		echo 'checked';
	}
	echo "><br>
	   Virtual 
	   <input name=\"rmanualt\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"0\" ";
	if ($ataprojeto->ata_tipo_manual[0] == 0) {
		echo 'checked';
	}
	echo "> 
	| Impresso
	<input name=\"rmanualt\" type=\"radio\" " . $contro_check . " style=\"border:0 ; color:#FFFFFF \" value=\"1\" ";
	if ($ataprojeto->ata_tipo_manual[0] == 1) {
		echo 'checked';
	}
	echo ">  
	<br></p></td>";

	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>';
	/* <tr>
	   <td width="10" height="20" bgcolor="#FFFFFF">&nbsp;</td>';
	   echo "<td height=\"20\" bgcolor=\"#FFFFFF\">".$ataprojeto->ata_tipo_manual[0]."</td>";
	   echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	 </tr> */
	echo '</table>
	      <br>';
	echo '<table width="735" border="0" cellspacing="0" cellpadding="0"
	style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 1pt;  PADDING-LEFT: 2pt;  PADDING-BOTTOM: 1pt; BORDER-LEFT: windowtext 1pt solid; BORDER-TOP:  windowtext 1pt solid; PADDING-TOP: 4pt; BORDER-BOTTOM: windowtext 1pt solid; mso-border-alt: solid windowtext .5pt; mso-shading: white; mso-pattern: gray-5 auto"
	>
	        <tr>
	          <td height="15" bgcolor="#F2F2F2">&nbsp;</td>
	          <td height="15" bgcolor="#F2F2F2"><strong>CONCLUS&Atilde;O </strong></td>
	          <td width="13" height="15" bgcolor="#F2F2F2">&nbsp;</td>
	        </tr>
	        <tr>
	          <td width="10" height="19" bgcolor="#FFFFFF">&nbsp;</td>';
	echo "<td width=\"727\" bgcolor=\"#FFFFFF\"><textarea name=\"text_esc_concl\"  " . $contro_indent . " cols=\"100\" rows=\"2\" wrap=\"VIRTUAL\">" . $ataprojeto->ata_conclusao[0] . "</textarea> </td>";
	echo '<td bgcolor="#FFFFFF">&nbsp;</td>
	        </tr>
	      </table>
	      <br>';

	//INICIO ACEITE DE DEFINIÇÃO DE ESCOPO
	if ($_SESSION['profilSession'] == 1 && $ataprojeto->ata_aceite[0] != 1) {

		echo "<form name=\"form1\" method=\"post\" action=\"home.php?upProject=true&" . session_name() . "=" . session_id() . "\">";
		echo '<table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
		    <tr>
		      <td width="13">&nbsp;</td>
		      <td width="474">&nbsp;</td>
		      <td width="13">&nbsp;</td>
		    </tr>
		    <tr>
		      <td>&nbsp;</td>
		      <td align="center">Confirma&ccedil;&atilde;o de Aceite de Defini&ccedil;&atilde;o de Escopo<input type="hidden" name="aceite" value="1"><input type="hidden" name="idpro"';
		echo "value=\"" . $projectDetail->pro_id[0] . "\">";
		echo '</td>
		      <td>&nbsp;</td>
		    </tr>
		    <tr>
		      <td height="10"></td>
		      <td height="10"></td>
		      <td height="10"></td>
		    </tr>
		    <tr>
		      <td>&nbsp;</td>
		      <td align="center"><input type="submit" name="Submit" value="ACEITO" style="FONT-SIZE: 9pt; mso-bidi-font-size: 10.0pt"><br></td>
		      <td>&nbsp;</td>
		    </tr>
		  </table><br>
		</form>';
	} else
		if ($ataprojeto->ata_aceite[0] == 1) {

			echo '<table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
			    <tr>
			      <td width="13">&nbsp;</td>
			      <td width="474">&nbsp;</td>
			      <td width="13">&nbsp;</td>
			    </tr>
			    <tr>
			      <td>&nbsp;</td>
			      <td align="center"></td>
			      <td>&nbsp;</td>
			    </tr>
			    <tr>
			      <td height="10"></td>
			      <td height="10"></td>
			      <td height="10"></td>
			    </tr>
			    <tr>
			      <td>&nbsp;</td>
			      <td align="center">>Escopo Aceito Pelo Gerente de Projeto, data do aceite:';
			echo $ataprojeto->ata_data_aceite[0] . "<";
			echo '<br></td>
			      <td>&nbsp;</td>
			    </tr>
			  </table><br>';

		} else
			if ($_SESSION['profilSession'] != 1 && $ataprojeto->ata_aceite[0] != 1) {

				echo '<table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
				    <tr>
				      <td width="13">&nbsp;</td>
				      <td width="474">&nbsp;</td>
				      <td width="13">&nbsp;</td>
				    </tr>
				    <tr>
				      <td>&nbsp;</td>
				      <td align="center"></td>
				      <td>&nbsp;</td>
				    </tr>
				    <tr>
				      <td height="10"></td>
				      <td height="10"></td>
				      <td height="10"></td>
				    </tr>
				    <tr>
				      <td>&nbsp;</td>
				      <td align="center"> >Em Processo de Aceite pela TI< <br></td>
				      <td>&nbsp;</td>
				    </tr>
				  </table><br>';

			}
	//FIM DE ACEITE DE DEFINIÇÃO DE ESCOPO

	echo '</table>'; //fim tela escopo 


}

// fim indentificaçao da demanda

//Inicio Fases da Demanda

//
function mostra_fase($sell, $nome, $des, $idfase, $tipo = '0') {
	global $contro_select, $contro_faseselect, $id;
	$sel = $sell;
	$campo = "<select id=\"" . $nome . "\" name=\"" . $nome . "\" class=\"text_10\" " . $contro_faseselect . " onChange=\"onjanela('criapedente.php?proj=" . $id . "&tipo=" . $tipo . "&idfase=" . $idfase . "','pedente','250','150',this.value);\">
	<option value=\"0\"";
	if ($sel == 0) {
		$campo .= ' selected';
	}
	$campo .= ">>N&atilde;o Iniciado<</option>
	<option value=\"1\"";
	if ($sel == 1) {
		$campo .= ' selected';
	}
	$campo .= ">Em Andamento</option>
	<option value=\"4\"";
	if ($sel == 4) {
		$campo .= ' selected';
	}
	$campo .= ">Pendente</option>
	<option value=\"2\"";
	if ($sel == 2) {
		$campo .= ' selected';
	}
	$campo .= ">Concluido</option>";
	if (!$des == 1) {
		$campo .= "<option value=\"3\"";
		if ($sel == 3) {
			$campo .= ' selected';
		}
		$campo .= ">N&atilde;o se Aplica</option>";
	}

	$campo .= "</select>";

	return $campo;

}

/*
//INI GESTAO DE RECURSO
if (($profilSession == 6) || ($profilSession == 10)) {

	$block_recurso = new block();

	$block_recurso->heading("<a href=\"#\" onClick=\"verif('imgrecurso','mosfase','mrecurso','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgrecurso\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a> " . $strings["gestao_recurso"] . " ");

	//TOTAL DE HORAS DO PROJETO
	$tmppro = " WHERE RPRO.nu_seq_projeto= '" . $projectDetail->pro_id[0] . "' AND RPRO.NU_SEQ_ATIVIDADE IS NOT NULL";
	$reqPro = new request();
	$reqPro->openRecprojeto($tmppro);
	$contreqPro = count($reqPro->recpro_id);
	//echo $contreqPro;
	for ($c = 0; $c < $contreqPro; $c++) {
		$total_pro = $total_pro + $reqPro->recpro_hora[$c];
	}
	unset ($reqPro);

	//echo "<form name=\"form1\" class=\"func\" method=\"post\" onSubmit=\"return verifica();\">";
	echo "<table  id='mrecurso' cellspacing='0' width='95%' border='0' cellpadding='3' cols='4' class='listing' style=\"display:none\" onMouseOver=\"scrollver();\">";
	echo '<tr valign="top"><td >';
	echo '<table width="100%" border="0" cellspacing="0" cellpadding="0">
	  <tr >
	    <td width="18%" height="10%" class="top_botton">DEMANDA:</td>
	    <td width="9%" class="top_botton">&nbsp;</td>
	    <td width="8%" class="top_botton">HORAS:</td>';
	//VERIFICA VARIAVEL DTR
	if ($dtr != "") {
		$anor = substr("$dtr", 0, 4);
		$mesr = substr("$dtr", 5, 2);
		$mesver = substr("$dtr", 5, 1);
		if ($mesver == 0) {
			$mes_ct = substr("$dtr", 6, 1);
		} else {
			$mes_ct = $mesr;
		}
	} else {
		$anor = date('Y');
		$mesr = date('m');
		$mesver = substr("$mesr", 0, 1);
		if ($mesver == 0) {
			$mes_ct = substr("$mesr", 1, 1);
		} else {
			$mes_ct = $mesr;
		}
	}
	echo "<td width=\"65%\" colspan=\"35\" align=\"center\" class=\"top_botton\">" . $monthNameArray[$mes_ct] . "-" . $anor . "<div>" . $block_recurso->buildLink("../projects_site/home.php?dtr=" . anteriorct($mesr, $anor) . "", "<img src=\"../themes/default/btn_seta_left.gif\" width=\"10\" height=\"10\" border=\"0\" title=\"anterior\" align=\"left\">", in) . " " . $block_recurso->buildLink("../projects_site/home.php?dtr=" . proximoct($mesr, $anor) . "", "<img src=\"../themes/default/btn_seta_right.gif\" width=\"10\" height=\"10\" border=\"0\" title=\"proximo\" align=\"right\">", in) . "</div></td>";
	echo '</tr>
	  <tr>
	    <td height="24" align="center" class="lateral_left">Total de Horas</td>
	    <td height="24" align="center">&nbsp;</td>';
	echo "<td height=\"20\" align=\"center\" class=\"lateral\">" . $total_pro . "h</td>";
	echo '<td height="18" align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">T</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">D</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">T</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">D</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">T</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">D</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">T</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">S</span></td>
		<td align="center" bgcolor="#c4d3db"><span class="table2">D</span></td>
		<td align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#F5F5F5"><span class="table2">T</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">Q</span></td>
		<td align="center" bgcolor="#F5F5F5"><span class="table2">Q</span></td>
	    <td align="center" bgcolor="#EFEFEF"><span class="table2">S</span></td>
	    <td align="center" bgcolor="#c4d3db"><span class="table2">S</span></td>
		<td align="center" bgcolor="#c4d3db" class="lateral_right"><span class="table2">D</span></td>
	    
	  </tr>';

	// INICIO MOSTRA FUNCAO
	$tmpfuncao = " WHERE RP.nu_seq_projeto='" . $projectDetail->pro_id[0] . "' ORDER BY SF.no_sub_funcao_sgd ASC ";
	$reqfuncao = new request();
	$reqfuncao->openFuncaocontrol($tmpfuncao);
	$contreqFuncao = count($reqfuncao->func_id);
	//

	for ($i = 0; $i < $contreqFuncao; $i++) {

		//INICIO USUARIO FUNCAO 
		$tmpreqfusu = " WHERE SF.NU_SEQ_SUB_FUNCAO_SGD='" . $reqfuncao->func_id[$i] . "' AND RPRO.nu_seq_projeto='" . $projectDetail->pro_id[0] . "' ";
		$reqfusu = new request();
		$reqfusu->openRecursofuncao($tmpreqfusu);
		$contreqfusu = count($reqfusu->recf_id);
		//echo $contreqfusu ;
		//
		echo '<tr>
		    <td height="12" colspan="2" align="center" class="lateral_left">
			<table width="95%" border="0" cellspacing="0" cellpadding="0">
		      <tr>
		        <td width="10%">';
		echo "<input type=\"hidden\" id=\"qtdusu" . $reqfuncao->func_id[$i] . "\" name=\"qtdusu" . $reqfuncao->func_id[$i] . "\" value=\"" . $contreqfusu . "\"><input type=\"hidden\" id=\"mosrec" . $reqfuncao->func_id[$i] . "\" name=\"mosrec" . $reqfuncao->func_id[$i] . "\" value=\"0\"><a href=\"#\" onClick=\"verif2('imgrec" . $reqfuncao->func_id[$i] . "','mosrec" . $reqfuncao->func_id[$i] . "','usug" . $reqfuncao->func_id[$i] . "','1','" . $contreqfusu . "');\" class=\"asem\"><img id=\"imgrec" . $reqfuncao->func_id[$i] . "\" src=\"../themes/default/btn_soma.gif\" alt=\"\" border=\"0\"></a>";
		echo '</td>';
		echo "<td width=\"90%\" ><strong>" . $reqfuncao->func_descricao[$i] . "</strong></td>";
		echo '</tr>
		    </table></td>';

		echo '<td height="12" align="center" class="lateral">&nbsp;</td>';
		//echo '<td height="12" colspan="28" align="center">&nbsp;</td>';

		echo '<td height="18" align="center" bgcolor="#EFEFEF" ></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#c4d3db"></td>';
		echo '<td align="center" bgcolor="#EFEFEF"></td>';
		echo '<td align="center" bgcolor="#F5F5F5"></td>';
		echo '<td align="center" bgcolor="#EFEFEF">&nbsp;</td>';
		echo '<td align="center" bgcolor="#F5F5F5">&nbsp;</td>';
		echo '<td align="center" bgcolor="#EFEFEF">&nbsp;&nbsp;</td>';
		echo '<td align="center" bgcolor="#c4d3db">&nbsp;&nbsp;</td>';
		echo '<td align="center" bgcolor="#c4d3db" class="lateral_right">&nbsp;&nbsp;</td>';

		echo '</tr>';

		//FOR DE USUARIO
		for ($z = 0; $z < $contreqfusu; $z++) {

			//RP.nu_seq_atividade=RA.NU_SEQ_ATIVIDADE   AND
			$tmqr = " LEFT OUTER JOIN sgd_fnde.s_recurso_projeto RP ON RP.nu_seq_atividade=RA.NU_SEQ_ATIVIDADE
			  WHERE  FAS.id_projeto ='" . $projectDetail->pro_id[0] . "' AND RP.nu_seq_recurso_usuario='" . $reqfusu->recf_id[$z] . "'
			  AND FAS.TIPO_FASE IS NOT NULL
			  AND RP.nu_seq_atividade IS NOT NULL
			  ORDER BY RA.DESC_ATIVIDADE ASC ";
			$reqatv = new request();
			$reqatv->openRecursoativ($tmqr);
			$contreqatv = count($reqatv->rec_id);
			// echo $contreqatv;

			//PEGA O NOME DO E SOBRENOME
			$nome_usu = explode(" ", $reqfusu->recf_nousuario[$z]);
			$nome_completo = $nome_usu[0] . " " . $nome_usu[count($nome_usu) - 1];

			//TOTAL DE HORAS DO PROJETO E RECURSO
			$tmpprousu = " WHERE RPRO.nu_seq_projeto= '" . $projectDetail->pro_id[0] . "' AND  RPRO.NU_SEQ_RECURSO_USUARIO= '" . $reqfusu->recf_id[$z] . "' AND RPRO.NU_SEQ_ATIVIDADE IS NOT NULL";
			$reqProusu = new request();
			$reqProusu->openRecprohora($tmpprousu);
			$contreqProusu = $reqProusu->recpro_hora[0];

			echo "<tr id=\"usug" . $reqfuncao->func_id[$i] . $z . "\" style=\"display:none\">";
			echo '<td height="12" colspan="2" align="center" class="lateral_left">';
			echo "<input type=\"hidden\" id=\"usufuso" . $reqfuncao->func_id[$i] . $z . "\" name=\"usufuso" . $reqfuncao->func_id[$i] . $z . "\" value=\"" . $reqfusu->recf_id[$z] . "\"><input type=\"hidden\" id=\"contatv" . $reqfusu->recf_id[$z] . "\" name=\"contatv" . $reqfusu->recf_id[$z] . "\" value=\"" . $contreqatv . "\">";
			echo '<table width="95%" border="0" cellspacing="0" cellpadding="0">
					  <tr>
						
						<td width="5%">';
			echo "&nbsp;&nbsp;<input type=\"hidden\" id=\"mosusr" . $reqfusu->recf_id[$z] . "\" name=\"mosusr" . $reqfusu->recf_id[$z] . "\" value=\"0\"><a href=\"#\" onClick=\"verif2('imgatvg" . $reqfusu->recf_id[$z] . "','mosusr" . $reqfusu->recf_id[$z] . "','ativg" . $reqfusu->recf_id[$z] . "','0','" . $contreqatv . "');\" class=\"asem\"><img id=\"imgatvg" . $reqfusu->recf_id[$z] . "\" src=\"../themes/default/btn_soma.gif\" alt=\"\" border=\"0\"></a>";
			echo '</td>
						<td width="95%">';
			echo "<span style='font-size:9'>" . $nome_completo . "</span></td>";
			echo '</tr>
					</table>
				</td>';
			echo "<td height=\"12\" align=\"center\" class=\"lateral\">" . $contreqProusu . "h</td>";
			// echo '<td height="12" align="center" >&nbsp;</td>';
			//<td height="12" bgcolor="#EFEFEF" colspan="35" align="center">&nbsp;</td>
			echo '<td height="18" align="center" bgcolor="#EFEFEF" ></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#c4d3db"></td>';
			echo '<td align="center" bgcolor="#EFEFEF"></td>';
			echo '<td align="center" bgcolor="#F5F5F5"></td>';
			echo '<td align="center" bgcolor="#EFEFEF">&nbsp;</td>';
			echo '<td align="center" bgcolor="#F5F5F5">&nbsp;</td>';
			echo '<td align="center" bgcolor="#EFEFEF">&nbsp;&nbsp;</td>';
			echo '<td align="center" bgcolor="#c4d3db">&nbsp;&nbsp;</td>';
			echo '<td align="center" bgcolor="#c4d3db" class="lateral_right">&nbsp;&nbsp;</td>';

			echo '</tr>';

			unset ($reqProusu);
			//
			for ($y = 0; $y < $contreqatv; $y++) {

				//TOTAL DE HORAS DO PROJETO E RECURSO E ATIVIDADE
				$tmpproatv = " WHERE RPRO.nu_seq_projeto= '" . $projectDetail->pro_id[0] . "' AND  RPRO.NU_SEQ_RECURSO_USUARIO= '" . $reqfusu->recf_id[$z] . "' AND RPRO.NU_SEQ_ATIVIDADE ='" . $reqatv->rec_id[$y] . "' AND RPRO.NU_SEQ_ATIVIDADE IS NOT NULL ";
				$reqProatv = new request();
				$reqProatv->openRecprohora($tmpproatv);
				$contreqProatv = $reqProatv->recpro_hora[0];

				unset ($reqProatv);

				echo "<tr id=\"ativg" . $reqfusu->recf_id[$z] . $y . "\" style=\"display:none\">";
				echo '<td height="12" colspan="2" align="center" class="lateral_left">
					<table width="90%" border="0" cellspacing="0" cellpadding="0">
				      <tr>';
				echo "<td>&nbsp;<input type=\"hidden\" id=\"fuso" . $y . "\" name=\"fuso" . $y . "\" value=\"" . $reqfusu->recf_id[$z] . "\">";
				echo '</td>';

				echo '<td>' . $reqatv->rec_descricao[$y] . '</td>
				      </tr>
					</table></td>';
				echo "<td height=\"12\" align=\"center\" class=\"lateral\">" . $contreqProatv . "h</td>";

				//RECURSO PROJETO
				$tmppro1 = " WHERE RPRO.nu_seq_projeto= '" . $projectDetail->pro_id[0] . "' AND  RPRO.NU_SEQ_RECURSO_USUARIO='" . $reqfusu->recf_id[$z] . "' AND RPRO.NU_SEQ_ATIVIDADE='" . $reqatv->rec_id[$y] . "' AND RPRO.NU_SEQ_ATIVIDADE IS NOT NULL AND RPRO.DT_RECURSO_PROJETO LIKE '" . $anor . "-" . $mesr . "%' ";
				$reqPro1 = new request();
				$reqPro1->openRecprojeto($tmppro1);
				$contreqPro1 = count($reqPro1->recpro_id);
				//

				$dia1 = mostra_dia("Monday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '01');
				$dia2 = mostra_dia("Tuesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '02');
				$dia3 = mostra_dia("Wednesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '03');
				$dia4 = mostra_dia("Thursday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '04');
				$dia5 = mostra_dia("Friday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '05');
				$dia6 = mostra_dia("Saturday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '06');
				$dia7 = mostra_dia("Sunday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '01', '07');
				$dia8 = mostra_dia("Monday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '02', '08');
				$dia9 = mostra_dia("Tuesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '03', '09');
				$dia10 = mostra_dia("Wednesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '04', '10');
				$dia11 = mostra_dia("Thursday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '05', '11');
				$dia12 = mostra_dia("Friday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '06', '12');
				$dia13 = mostra_dia("Saturday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '07', '13');
				$dia14 = mostra_dia("Sunday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '08', '14');
				$dia15 = mostra_dia("Monday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '09', '15');
				$dia16 = mostra_dia("Tuesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '10', '16');
				$dia17 = mostra_dia("Wednesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '11', '17');
				$dia18 = mostra_dia("Thursday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '12', '18');
				$dia19 = mostra_dia("Friday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '13', '19');
				$dia20 = mostra_dia("Saturday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '14', '20');
				$dia21 = mostra_dia("Sunday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '15', '21');
				$dia22 = mostra_dia("Monday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '16', '22');
				$dia23 = mostra_dia("Tuesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '17', '23');
				$dia24 = mostra_dia("Wednesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '18', '24');
				$dia25 = mostra_dia("Thursday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '19', '25');
				$dia26 = mostra_dia("Friday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '20', '26');
				$dia27 = mostra_dia("Saturday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '21', '27');
				$dia28 = mostra_dia("Sunday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '22', '28');
				$dia29 = mostra_dia("Monday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '23', '29');
				$dia30 = mostra_dia("Tuesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '24', '30');
				$dia31 = mostra_dia("Wednesday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '25', '31');
				$dia32 = mostra_dia("Thursday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '26', '31');
				$dia33 = mostra_dia("Friday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '27', '31');
				$dia34 = mostra_dia("Saturday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '28', '31');
				$dia35 = mostra_dia("Sunday", $reqPro1->recpro_data, $reqPro1->recpro_hora, '29', '31');

				echo '<td height="18" align="center" bgcolor="#EFEFEF" >' . $dia1 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia2 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia3 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia4 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia5 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia6 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia7 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia8 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia9 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia10 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia11 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia12 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia13 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia14 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia15 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia16 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia17 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia18 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia19 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia20 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia21 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia22 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia23 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia24 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia25 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia26 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia27 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia28 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia29 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia30 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia31 . '</td>';
				echo '<td align="center" bgcolor="#F5F5F5">' . $dia32 . '</td>';
				echo '<td align="center" bgcolor="#EFEFEF">' . $dia33 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db">' . $dia34 . '</td>';
				echo '<td align="center" bgcolor="#c4d3db" class="lateral_right">' . $dia35 . '</td>';

				echo '</tr>';
			} //FIM ATIVIDADE 

		} //FIM USUARIO FUNCAO 
		echo '<tr>
		    <td  colspan="38" align="center" class="lateral">';
		echo "<input type=\"hidden\" id=\"contusus" . $reqfuncao->func_id[$i] . "\" name=\"contusus" . $reqfuncao->func_id[$i] . "\" value=\"" . $contreqfusu . " \"><input type=\"hidden\" id=\"ctfuncao" . $reqfuncao->func_id[$i] . "\" name=\"ctfuncao" . $reqfuncao->func_id[$i] . "\" value=\"" . $contreqfusu . " \">";
		echo '</td>
		  </tr>';
	}
	echo '<tr >
	    <td width="100%" height="8%" colspan="38" class="bottom_lateral">&nbsp;</td>
	  </tr>
	</table>';

	echo '</td></tr>';
	echo '</table>'; //fim tela recurso

}
//FIM GESTAO DE RECURSO		
//
*/

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

//Inicio Planejado 1
$tmpqfas = " WHERE fas.id_projeto = '" . $projectDetail->pro_id[0] . "' and fas.tipo_fase = '1'";
$requestfase = new request();
$requestfase->openFases($tmpqfas);

//return $v ;
//}
//echo "<br>id ".$requestfase->fas_dat_ini_real[0];
//Inicio Processo 2
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
//fim Implantação 7

//Inicio Planejado 1
include ("../includes/calendar.php");
$block_fases = new block();

$block_fases->heading("<a href=\"#\" onClick=\"verif('imgfase','mosfase','mfase','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgfase\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a> " . $strings["fase_demanda"]);

if ($profilSession == 6 || $profilSession == 10 || $profilSession == 9 || $profilSession == 7) {
	
	echo "	<table  id='mfase' cellspacing='0' width='90%' border='0' cellpadding='3' cols='4' class='listing' style=\"display:none\">";
	//COMPONENTE DE COMPLEXIDADE
	function complexo($value, $pl) {

		if ($pl == 6) {
			$print = "<div style=\" height:10; position:absolute; right: 137px; \">Complexidade: <select id='mfase' name='select_complex' >
								  <option value=\"0\">Selecione Complexidade</option>
								  <option value=\"1\"  ";
			if ($value == 1) {
				$print .= 'selected';
			}
			$print .= ">baixa</option>
								  <option value=\"2\" ";
			if ($value == 2) {
				$print .= 'selected';
			}
			$print .= ">media</option>
								  <option value=\"3\" ";
			if ($value == 3) {
				$print .= 'selected';
			}
			$print .= ">alta</option>
								  </select></div>";
		} else {
			$print = "<div style=\"  height:10; position:absolute; right: 137px; \">Complexidade: ";
			if ($value == 1) {
				$print .= '<strong>baixa</strong>';
			}
			if ($value == 2) {
				$print .= '<strong>media</strong>';
			}
			if ($value == 3) {
				$print .= '<strong>alta</strong>';
			}
			$print .= "</div>";

		}
		return $print;

	}
	//

	if ($idSession == $projectDetail->pro_owner[0] || $profilSession == 6 || $profilSession == 9 || $profilSession == 10) {
		if ($requestfase->fas_dat_ini_plan[0] == "") {
			//echo "Click em Adcionar";
		} else {
			// echo "Data de Realização- ".$requestfase->fas_data[0].""; 
			echo "<tr ><td colspan='7'>";
			if ($profilSession == 6) {
				echo "<a href='editproject.php?removefase=true&idproject=" . $projectDetail->pro_id[0] . "'><img  id=\"admmm\" src=\"../themes/" . THEME . "/btn_remove_norm.gif\" alt=\"\" border=\"0\" onmouseover=\"trocaImg('btn_remove_over.gif','admmm');\" onmouseout=\"trocaImg('btn_remove_norm.gif','admmm');\" style=\"display:''\"></a>"; //Remover Cronograma 
			}
			echo "Data de Realização- " . $requestfase->fas_data[0] . "" . complexo($projectDetail->pro_hourly_rate[0], $profilSession) . "<br><br></td></tr>";
		}
	}

	echo "<tr>
						<th style=\"width:'10'\">" . $strings["name"] . "<input type=\"hidden\" name=\"gfase\" value=\"" . faseconsul($projectDetail->pro_id[0]) . "\"></th>
						<th style=\"width:'120'\">" . $strings["dt_inicop"] . "</th>
						<th style=\"width:'100'\">" . $strings["dt_fimcop"] . "</th>
						<th style=\"width:'120'\">" . $strings["dt_inicre"] . "</th>
						<th style=\"width:'100'\">" . $strings["dt_fimre"] . "</th>
						<th style=\"width:'100'\">" . $strings["status"] . "</th>
						<th style=\"width:'10'\">" . $strings["justifica"] . "</th>
					</tr>";

	function fasepd($id, $idfase) {
		$tmpquery = "WHERE fasp.id_fase = '" . $idfase . "' and fasp.id_projeto = '" . $id . "'";
		$testPedente = new request();
		$testPedente->openFasep($tmpquery);
		$contp = count($testPedente->fasp_id);

		if ($contp > 0) {
			$val = 1;
		} else {
			$val = 0;
		}

		return $val;

	}
	//

	function mosinput($name, $varivel, $area) {
		global $contro_fase, $profilSession, $contro_display;
		if ($varivel == "") {

			$campo = "<input name=\"" . $name . "\" class=\"text_10\" type=\"text\" id=\"" . $name . "\" size=\"12\" maxlength=\"11\" " . $contro_fase . " onChange=\"return isValidData(" . $name . ",'" . $name . "','" . $name . "');\"> <img src=\"../themes/default/btn_invoicing_norm.gif\" width=\"17\" height=\"17\" border=\"0\" align=\"absmiddle\" " . $contro_display . " onclick=\"return showCalendar('" . $name . "', '%d-%m-%Y');\">";

		} else {
			if ($area > 0) {
				$campo = "<input name=\"" . $name . "\" class=\"text_10\" type=\"text\" id=\"" . $name . "\" size=\"12\" maxlength=\"11\" " . $contro_fase . " value=\"" . invert_data($varivel) . "\"  onChange=\"return isValidData(" . $name . ",'" . $name . "','" . $name . "');\"> <img src=\"../themes/default/btn_invoicing_norm.gif\" width=\"17\" height=\"17\" border=\"0\" align=\"absmiddle\" " . $contro_display . " onclick=\"return showCalendar('" . $name . "', '%d-%m-%Y');\">";
			} else {
				if ($profilSession == 0 || $profilSession == 6 || $profilSession == 9) {
					$campo = "<input name=\"" . $name . "\" class=\"text_10\" type=\"text\" id=\"" . $name . "\" size=\"12\" maxlength=\"11\" " . $contro_fase . " value=\"" . invert_data($varivel) . "\"  onChange=\"return isValidData(" . $name . ",'" . $name . "','" . $name . "');\"> <img src=\"../themes/default/btn_invoicing_norm.gif\" width=\"17\" height=\"17\" border=\"0\" align=\"absmiddle\" " . $contro_display . " onclick=\"return showCalendar('" . $name . "', '%d-%m-%Y');\">";
				} else {
					$campo = invert_data($varivel) . "<input name=\"" . $name . "\"  type=\"hidden\" id=\"" . $name . "\" size=\"12\" maxlength=\"11\" value=\"" . $varivel . "\">";
				}
			}
		}

		return $campo;
	}

	$campo_fase = mosinput('text_fase', $requestfase->fas_dat_ini_plan[0], '0');
	$campo_fase_dfimp = mosinput('text_fase_dfimp', $requestfase->fas_dat_fim_plan[0], '0');
	$campo_fase_dinir = mosinput('text_fase_dinir', $requestfase->fas_dat_ini_real[0], '1');
	$campo_fase_dfimr = mosinput('text_fase_dfimr', $requestfase->fas_dat_fim_real[0], '1');
	$campo_f = fasepd($requestfase->fas_idpro[0], $requestfase->fas_id[0]);
	echo "<tr class='odd'>
					<td width='15%' >&nbsp;Planejamento</td><td width='20%'>&nbsp;" . $campo_fase . "</td><td width='25%'>&nbsp;" . $campo_fase_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_fase_dinir . "</td><td width='20%'>&nbsp;" . $campo_fase_dfimr . "</td><td >&nbsp;" . mostra_fase($requestfase->fas_status[0], 'm_pla', '1', $requestfase->fas_id[0], $requestfase->fas_tipo[0]) . "</td>
				   <td width='10%' align=\"center\">";
	if (($requestfase->fas_status[0] == 4) && ($campo_f == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requestfase->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";

	$campo_pro = mosinput('text_pro', $requestpro->fas_dat_ini_plan[0], '0');
	$campo_pro_dfimp = mosinput('text_pro_dfimp', $requestpro->fas_dat_fim_plan[0], '0');
	$campo_pro_dinir = mosinput('text_pro_dinir', $requestpro->fas_dat_ini_real[0], '1');
	$campo_pro_dfimr = mosinput('text_pro_dfimr', $requestpro->fas_dat_fim_real[0], '1');
	$campo_pr = fasepd($requestpro->fas_idpro[0], $requestpro->fas_id[0]);
	echo "<tr class='even'>
					<td width='15%' >&nbsp;Processo</td><td width='20%'>&nbsp;" . $campo_pro . "</td><td width='25%'>&nbsp;" . $campo_pro_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_pro_dinir . "</td><td width='20%'>&nbsp;" . $campo_pro_dfimr . "</td><td >&nbsp;" . mostra_fase($requestpro->fas_status[0], 'm_pro', '0', $requestpro->fas_id[0], $requestpro->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requestpro->fas_status[0] == 4) && ($campo_pr == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requestpro->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";

	$campo_den = mosinput('text_den', $requestden->fas_dat_ini_plan[0], '0');
	$campo_den_dfimp = mosinput('text_den_dfimp', $requestden->fas_dat_fim_plan[0], '0');
	$campo_den_dinir = mosinput('text_den_dinir', $requestden->fas_dat_ini_real[0], '1');
	$campo_den_dfimr = mosinput('text_den_dfimr', $requestden->fas_dat_fim_real[0], '1');
	$campo_de = fasepd($requestden->fas_idpro[0], $requestden->fas_id[0]);
	echo "<tr class='odd'>
					<td width='15%' >&nbsp;Desenvolvimento</td><td width='20%'>&nbsp;" . $campo_den . "</td><td width='25%'>&nbsp;" . $campo_den_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_den_dinir . "</td><td width='20%'>&nbsp;" . $campo_den_dfimr . "</td><td >&nbsp;" . mostra_fase($requestden->fas_status[0], 'm_den', '0', $requestden->fas_id[0], $requestden->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requestden->fas_status[0] == 4) && ($campo_de == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requestden->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";

	$campo_teste = mosinput('text_tes', $requesttes->fas_dat_ini_plan[0], '0');
	$campo_teste_dfimp = mosinput('text_tes_dfimp', $requesttes->fas_dat_fim_plan[0], '0');
	$campo_teste_dinir = mosinput('text_tes_dinir', $requesttes->fas_dat_ini_real[0], '1');
	$campo_teste_dfimr = mosinput('text_tes_dfimr', $requesttes->fas_dat_fim_real[0], '1');
	$campo_te = fasepd($requesttes->fas_idpro[0], $requesttes->fas_id[0]);
	echo "<tr class='even'>
					<td width='15%' >&nbsp;Teste</td><td width='20%'>&nbsp;" . $campo_teste . "</td><td width='25%'>&nbsp;" . $campo_teste_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_teste_dinir . "</td><td width='20%'>&nbsp;" . $campo_teste_dfimr . "</td><td >&nbsp;" . mostra_fase($requesttes->fas_status[0], 'm_tes', '0', $requesttes->fas_id[0], $requesttes->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requesttes->fas_status[0] == 4) && ($campo_te == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requesttes->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";

	$campo_hom = mosinput('text_hom', $requesthom->fas_dat_ini_plan[0], '0');
	$campo_hom_dfimp = mosinput('text_hom_dfimp', $requesthom->fas_dat_fim_plan[0], '0');
	$campo_hom_dinir = mosinput('text_hom_dinir', $requesthom->fas_dat_ini_real[0], '1');
	$campo_hom_dfimr = mosinput('text_hom_dfimr', $requesthom->fas_dat_fim_real[0], '1');
	$campo_ho = fasepd($requesthom->fas_idpro[0], $requesthom->fas_id[0]);
	echo "<tr class='odd'>
					<td width='15%' >&nbsp;Homologação</td><td width='20%'>&nbsp;" . $campo_hom . "</td><td width='25%'>&nbsp;" . $campo_hom_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_hom_dinir . "</td><td width='20%'>&nbsp;" . $campo_hom_dfimr . "</td><td >&nbsp;" . mostra_fase($requesthom->fas_status[0], 'm_hom', '0', $requesthom->fas_id[0], $requesthom->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requesthom->fas_status[0] == 4) && ($campo_ho == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requesthom->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";

	$campo_cap = mosinput('text_cap', $requestcap->fas_dat_ini_plan[0], '0');
	$campo_cap_dfimp = mosinput('text_cap_dfimp', $requestcap->fas_dat_fim_plan[0], '0');
	$campo_cap_dinir = mosinput('text_cap_dinir', $requestcap->fas_dat_ini_real[0], '1');
	$campo_cap_dfimr = mosinput('text_cap_dfimr', $requestcap->fas_dat_fim_real[0], '1');
	$campo_c = fasepd($requestcap->fas_idpro[0], $requestcap->fas_id[0]);
	echo "<tr class='even'>
					<td width='15%' >&nbsp;Treinamento</td><td width='20%'>&nbsp;" . $campo_cap . "</td><td width='25%'>&nbsp;" . $campo_cap_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_cap_dinir . "</td><td width='20%'>&nbsp;" . $campo_cap_dfimr . "</td><td >&nbsp;" . mostra_fase($requestcap->fas_status[0], 'm_trei', '0', $requestcap->fas_id[0], $requestcap->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requestcap->fas_status[0] == 4) && ($campo_c == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requestcap->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";
	$campo_imp = mosinput('text_imp', $requestimp->fas_dat_ini_plan[0], '0');
	$campo_imp_dfimp = mosinput('text_imp_dfimp', $requestimp->fas_dat_fim_plan[0], '0');
	$campo_imp_dinir = mosinput('text_imp_dinir', $requestimp->fas_dat_ini_real[0], '1');
	$campo_imp_dfimr = mosinput('text_imp_dfimr', $requestimp->fas_dat_fim_real[0], '1');
	$campo_i = fasepd($requestimp->fas_idpro[0], $requestimp->fas_id[0]);
	echo "<tr class='odd'>
					<td width='15%' >&nbsp;Implantação</td><td width='20%'>&nbsp;" . $campo_imp . "</td><td width='25%'>&nbsp;" . $campo_imp_dfimp . "</td>
					<td width='20%'>&nbsp;" . $campo_imp_dinir . "</td><td width='20%'>&nbsp;" . $campo_imp_dfimr . "</td><td >&nbsp;" . mostra_fase($requestimp->fas_status[0], 'm_impla', '1', $requestimp->fas_id[0], $requestimp->fas_tipo[0]) . "</td>
				  <td width='10%' align=\"center\">";
	if (($requestimp->fas_status[0] == 4) && ($campo_i == 1)) {
		echo "<img src=\"../themes/default/btn_edit_norm.gif\" width=\"20\" height=\"20\" title=\"Justificar Pendência\" border=\"0\" cursor:hand style=\"display:''; cursor:hand\" onClick=\"janela('abrepedente.php?idpend=" . $requestimp->fas_id[0] . "','pedente','250','150');\">";
	}
	echo "</td>
				  </tr>";
	echo "<tr><td align=\"center\" colspan=\"6\"><BR></td></tr></table>";

	// echo '</form>';
	//inicio Solicita mudança 
	$tmpimpsom = " WHERE som.id_projeto = '" . $projectDetail->pro_id[0] . "'";
	$requestsom = new request();
	$requestsom->openMudanca($tmpimpsom);

	//fim Solicita mudança

	$block_mudanca = new block();
	if ($profilSession == 6 || $profilSession == 7) {
		$block_mudanca->heading("<a href=\"#\" onClick=\"verif('imgmuda','mosdemanda','muda','adm');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgmuda\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a> " . $strings["so_mudanca"]);

		echo "\t\t<a href='addmudanca.php?$transmitSid&project=" . $projectDetail->pro_id[0] . "'><img  id=\"adm\" src=\"../themes/" . THEME . "/btn_add_norm.gif\" alt=\"\" border=\"0\" onmouseover=\"trocaImg('btn_add_over.gif','adm');\" onmouseout=\"trocaImg('btn_add_norm.gif','adm');\" style=\"display:none\"></a>";
	} else {
		$block_mudanca->heading("<a href=\"#\" onClick=\"verif('imgmuda','mosdemanda','muda','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgmuda\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a> " . $strings["so_mudanca"]);

	}
	//if($requestsom->som_id=="") {echo "Sem solicitação de mudança";	} 
	if ($requestsom->som_id == "") {
		echo "<table id='muda' cellspacing='0' width='90%' border='0' cellpadding='3' cols='4' class='listing' style=\"display:none\">
							<tr><td></td></tr></table>";
	} else
		if (!$requestsom->som_id == "") {
			echo "<table id='muda' cellspacing='0' width='90%' border='0' cellpadding='3' cols='4' class='listing' style=\"display:none\">
								<tr>
									<th width='15%'>" . $strings["id"] . "</th>
									<th width='20%'>" . $strings["titulo"] . "</th>
									<th width='25%'>" . $strings["dt_abertura"] . "</th>
									<th>" . $strings["descricao"] . "</th>
								</tr>";
			$cont_som = 0;
			for ($k = 0; $k < count($requestsom->som_id); $k++) {
				$b = $k;
				$a_som = $k % 2;
				if ($a_som > 0) {
					$class_som = 'odd';
				} else {
					$class_som = 'even';
				}
				$desc_som = "";
				$desc_som = substr($requestsom->som_descricao[$k], 0, 48);
				$detanha = "DETALHAMENTO: ";
				//$requestsom->som_id[$k]
				echo "<tr class='$class_som'>
											<td width='15%'>" . $projectDetail->pro_id[0] . "-" . ++ $b . "</td>
											<td width='20%'>" . $requestsom->som_titulo[$k] . "</td>
											<td width='25%'>" . invert_data($requestsom->som_data[$k]) . "</td>
											<td title='" . $detanha . $requestsom->som_descricao[$k] . "' >" . $desc_som . "</td>
									  </tr>";
			}
			echo "</table>";
		} //fim mudança
	//inicio verifica se ja tem aceite 
	$tmpsati = "WHERE ta.id_projeto = '" . $projectDetail->pro_id[0] . "'";
	$requestt = new request();
	$requestt->openTermo($tmpsati);
	$contt = count($requestt->ter_id);
	//if($contt <= 0){
	if ($contt > 0) {
		//inicio termo de aceite 
		$block_termo = new block();
		$block_termo->heading("<a href=\"#\" onClick=\"verif('imgtermo','mostermo','termo','0');\" class=\"asem\"><strong style=color=\"blue\";font-size=\"23\"; font-weight: bold;><img id=\"imgtermo\" src=\"../themes/" . THEME . "/btn_soma.gif\" alt=\"\" border=\"0\"></strong></a> " . $strings["termoaceite"]);

		echo "<table id='termo' cellspacing='0' width='100%' border='0' cellpadding='3' cols='4'  style=\"display:none\">
				<tr>
					<td>";
		$termo = ($requestt->ter_relacionamento[0] + $requestt->ter_comunica[0] + $requestt->ter_alinha[0] + $requestt->ter_solucao[0] + $requestt->ter_prazo[0] + $requestt->ter_performace[0] + $requestt->ter_estabilidade[0] + $requestt->ter_erro[0] + $requestt->ter_atendimento[0] + $requestt->ter_pontualidade[0] + $requestt->ter_ambiente[0] + $requestt->ter_cenario[0]) / 60;
		
		if (($termo >= 0.80) && ($termo < 1.2)) {

			echo "Conclusão do projeto:&nbsp;<img  src=\"../themes/" . THEME . "/satisfeito.gif\" alt=\"\" border=\"0\"> Satisfeito";

		} else
			if (($termo < 0.80) && ($termo >= 0.49)) {

				echo "Conclusão do projeto:&nbsp;<img  src=\"../themes/" . THEME . "/razoavel.gif\" alt=\"\" border=\"0\"> A Desejar";

			} else
				if ($termo < 0.49) {

					echo "Conclusão do projeto:&nbsp;<img  src=\"../themes/" . THEME . "/ruim.gif\" alt=\"\" border=\"0\"> Insatisfeito";

				} else
					if ($termo >= 1.2) {

						echo "&nbsp;&nbsp;&nbsp;&nbsp;<img  src=\"../themes/" . THEME . "/indiferente.gif\" alt=\"\" border=\"0\"> Não Informado.";

					}

		function satis($num) {

			switch ($num) {

				case 1 :
					$campo = "Ruim ";
					break;
				case 2 :
					$campo = "Regular";
					break;
				case 3 :
					$campo = "Bom";
					break;
				case 4 :
					$campo = "Ótimo";
					break;
				case 5 :
					$campo = "Exelente";
					break;

			}

			return $campo;

		}

		echo "</td>
				</tr>";
		// inicio dados de satisfação 
		
		echo '<tr>
						 <td>';
		if ($termo < 1.2) {

			echo '<table width="98%" height="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
			        <tr>
			          <td height="5" colspan="4"></td>
			          </tr>';
			
			echo '<tr>
			          <td>&nbsp;</td>
			          <td width="28%">&nbsp;</td>
			          <td width="68%">&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th nowrap class="FormLabel" align="left" >1.Relacionamento:</th>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="odd">';
			$rel = satis($requestt->ter_relacionamento[0]);
			echo '<td>&nbsp;</td>
			          <td colspan="2">O cliente est&aacute; satisfeito com o atendimento da demanda ? </td>
			          <td>' . $rel . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th nowrap class="FormLabel" align="left" >2.Comunica&ccedil;&atilde;o:</th>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>';
			$comun = satis($requestt->ter_comunica[0]);
			echo '<tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">A comunica&ccedil;&atilde;o sobre o andamento da demanda foi ? </td>
			          <td>' . $comun . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th colspan="2" nowrap class="FormLabel" align="left" >3.Alinhamento com o neg&oacute;cio: </th>
			          <td>&nbsp;</td>
			        </tr>';
			$alin = satis($requestt->ter_alinha[0]);
			echo '<tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">Como est&aacute; o alinhamento da demanda com as necessidade do neg&oacute;cio? </td>
			          <td>' . $alin . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th colspan="2" nowrap class="FormLabel" align="left" >4.Resolu&ccedil;&atilde;o de problemas:</th>
			          <td>&nbsp;</td>
			        </tr>';
			$habi = satis($requestt->ter_solucao[0]);
			echo '<tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">A habilidade da equipe em indentificar, definir e solucionar problemas &eacute; ? </td>
			          <td>' . $habi . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th nowrap class="FormLabel" align="left" >5.Prazo das entregas:</th>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>';
			$praz = satis($requestt->ter_prazo[0]);
			echo '<tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">As entregas s&atilde;o realizadas conforme o combinado (Dentro do prazo) ? </td>
			          <td>' . $praz . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th colspan="2" nowrap class="FormLabel" align="left" >6.Qualidade de Entrega:</th>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">Com rela&ccedil;&atilde;o a qualidade de entrega como  foram relalizadas em rela&ccedil;&atilde;o a: </td>
			          <td>&nbsp;</td>
			        </tr>';
			$perfor = satis($requestt->ter_performace[0]);
			echo '
			        <tr class="even">
			          <td>&nbsp;</td>
			          <td>Performace - </td>
			          <td>
						
					  </td>
			          <td>' . $perfor . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>';
			$estab = satis($requestt->ter_estabilidade[0]);
			echo '
			        <tr class="odd">
			          <td>&nbsp;</td>
			          <td>Estabilidade - </td>
			          <td>
						
					  </td>
			          <td>' . $estab . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>';
			$erros = satis($requestt->ter_erro[0]);
			echo '
			        <tr class="even">
			          <td>&nbsp;</td>
			          <td>Gera&ccedil;&atilde;o de erros - </td>
			          <td>
						  
					  </td>
			          <td>' . $erros . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="even">
			          <td>&nbsp;</td>
			          <th colspan="2" nowrap class="FormLabel" align="left" >7.Teste e homloga&ccedil;&atilde;o: </th>
			          <td>&nbsp;</td>
			        </tr>
			        <tr class="odd">
			          <td>&nbsp;</td>
			          <td colspan="2">Qual foi a qualidade do teste/homloga&ccedil;&atilde;o em rela&ccedil;&atilde;o a ? </td>
			          <td>&nbsp;</td>
			        </tr>';
			$atend = satis($requestt->ter_atendimento[0]);
			echo '
			        <tr class="even">
			          <td>&nbsp;</td>
			          <td>Atendimento - </td>
			          <td>
						
					  </td>
			          <td>' . $atend . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>';
			$pont = satis($requestt->ter_pontualidade[0]);
			echo '
			        <tr class="odd">
			          <td>&nbsp;</td>
			          <td>Pontualidade - </td>
			          <td>
						
					  </td>
			          <td>' . $pont . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>';
			$hambie = satis($requestt->ter_ambiente[0]);
			echo '
			        <tr class="even">
			          <td>&nbsp;</td>
			          <td colspan=2	>Disponibilidade de ambiente - </td>
			          
			          <td>' . $hambie . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>';
			$cena = satis($requestt->ter_cenario[0]);
			echo '
			        <tr class="odd">
			          <td>&nbsp;</td>
			          <td>Cen&aacute;rios prontos - </td>
			          <td>
						
					  </td>
			          <td>' . $cena . '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			        </tr>
			        <tr>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			          <td>&nbsp;</td>
			        </tr>
			        
			        <tr>
			          <td height="5" colspan="4"></td>
			          </tr>
			        
			      </table>';
		} //if 1.2	 

		echo '</td>
					</tr>';

		// fim dados de satisfação
		echo "</table>";
	} //inicio termo de aceite

} else {
	//Sem solicitação de mudança
	echo "<table id='muda' cellspacing='0' width='90%' border='0' cellpadding='3' cols='4' class='listing' style=\"display:none\">
		<tr><td></td></tr>
		</table>";

} // fim profilsesssion ==
// Fim fase da demanda

echo "<input type=\"hidden\" id=\"mostermo\" name=\"mostermo\" value=\"0\"><input type=\"hidden\" id=\"mosfase\" name=\"mosfase\" value=\"0\"><input type=\"hidden\" id=\"mosdemanda\" name=\"mosdemanda\" value=\"0\"><input type=\"hidden\" id=\"mosescopo\" name=\"mosescopo\" value=\"0\"><input type=\"hidden\"  id=\"mosindent\" name=\"mosindent\" value=\"1\">";

$block1->openContent();

echo "<tr class='odd' ><td valign='top' class='leftvalue'>&nbsp;</td><td valign='top' class='leftvalue'>&nbsp;</td><td valign='top' class='leftvalue'>&nbsp;</td><td ><input type='SUBMIT' value='" . $strings["save"] . "'   class=\"text_10\"></td></tr>";

$block1->closeContent();
$block1->closeForm();

include ('../themes/' . THEME . '/footer.php');
?>
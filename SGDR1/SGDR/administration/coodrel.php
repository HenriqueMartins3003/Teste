<script language="JavaScript" type="text/javascript">
	function NovaJanela(arquivo, XX, YY){
		 var NovaJanela = window.open(arquivo , "antologia",'status=no,resizable=no,toolbar=no,location=no,menubar=no,scrollbars=yes,width=' + XX + ',height=' + YY);
		 NovaJanela.moveTo(25,30);
		 NovaJanela.focus();
	  }
</script>

<?php
$checkSession = "true";
include_once ('../includes/library.php');

include_once ('../includes/customvalues.php');

include_once ('../themes/default/header.php');

if (!$profilSession == 6) {
	headerFunction('../general/permissiondenied.php?' . session_name() . '=' . session_id());
	exit;
}

$tipo_usu = $_REQUEST['tipo_usu'];

//
if($tipo_usu == 6 ){
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_coordenador_relacionamento' ";
$tipo_usuario = "Gerenciamento de Coordenação de Relacionamento";
}
if($tipo_usu == 11){
//Coodenador de relatório
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_coor_relat' ";
$tipo_usuario = "Coordenador de Relátorio";
}
if($tipo_usu == 7){
//Analista de relacionamento
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_analista_relat' ";
$tipo_usuario = "Analista de Relacionamento";
}
if($tipo_usu == 0){
//Administrador
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_admin' ";
$tipo_usuario = "Administrador";
}
if($tipo_usu == 8){
//Gerencial
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_usuario' ";
$tipo_usuario = "Gerencial";
}
if($tipo_usu == 10){
//PMO
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_coor_fabric' ";
$tipo_usuario = "PMO";
}
if($tipo_usu == 1){
//PMO
$tmp_usuario = " AND SG.NO_GRUPO = 'sgd_gerente_projeto' ";
$tipo_usuario = "Gerente de projeto";
}


$sel_Usuario = new request();
$sel_Usuario->openSousuario($tmp_usuario);
$contUsuario = count($sel_Usuario->so_id);
//

//
$block1 = new block();

$block1->heading($tipo_usuario);
$block1->openContent("90%");
$block1->contentTitle($strings["admin_intro"], "5");

for ($i = 0; $i < $contUsuario; $i++) {

	$block1->openRow("");
	$block1->cellRow("", '5%', "", '25');
	$block1->cellRow($block1->buildLink("javascript:NovaJanela('Formcoord.php?id_usu=" . $sel_Usuario->so_id[$i] . "&tipo_usu=".$tipo_usu ."','560','310');", $sel_Usuario->so_nome[$i], "out"), '60%', "", '25');
	$block1->cellRow("", '35%', "", '25');
	$block1->closeRow();

}


$block1->closeContent();

include ('../themes/' . THEME . '/footer.php');
?>
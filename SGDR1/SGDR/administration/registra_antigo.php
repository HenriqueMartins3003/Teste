<?php
#Application name: SGD
#Status page: 1
#Path by root: ../projects/listprojects.php

$checkSession = "true";
include_once('../includes/library.php');

 if(!$profilSession == 6 || !$profilSession == 7){
 
headerFunction('../general/login.php?logout=true');
// echo "<script>window.location.href='../general/login.php?logout=true';</script>";
 
 }

//echo $loginSession;
if(!$text_nome=="" && !$text_descricao=="" && !$text_sistru=="" && !$text_sigla==""){

function organiza($sigla){
$tmp = "WHERE org.name= '".strtoupper(trim($sigla))."' ";
$listSistem = new request();
$listSistem->openOrganizations($tmp);
//echo "<br>";
$comp = $listSistem->org_id[0];
return $comp;
}

$resul = organiza(trim($text_sigla));
	if($resul > 0){
	echo "ja existe"; 
	echo $id_org = $resul;
	echo '<script>alert("Ja existe unidade!!!");</script>';
	}else{
	
	$tmpcad = "INSERT INTO sgd_fnde.organizations ( name, address1, address2,created, extension_logo, owner, hourly_rate) VALUES ('".strtoupper(trim($text_sigla))."','".$loginSession."@fnde.gov.br','".$loginSession."@fnde.gov.br','".date('Y-m-d')."','jpg','".$idSession."','0')";
	connectSql($tmpcad);
	echo "foi criado";
	echo $id_org = organiza(trim($text_sigla));
	
	}
	
	
	
	$tmpsis = "WHERE sis.id_unidade='".$id_org."' AND sis.nome= '".strtoupper(trim($text_nome))."' ";
	$listSis = new request();
	$listSis->openSistema($tmpsis);
	$countSis = count($listSis->sis_id);
	
			if($countSis > 0){
			echo '<script>alert("Ja existe sistema nesta unidade!!!");</script>';
			
			echo '<script>window.history(-1);</script>';
			
			}else {
			$tmpsistem = "INSERT INTO sgd_fnde.sistemas(id_unidade, nome, descricao, id_organizacao) VALUES ('".$id_org."','".strtoupper($text_nome)."','".strtoupper($text_descricao)."','".$text_sistru."')";
			connectSql($tmpsistem);
			
			echo '<script>alert("Cadastrado de Sistema com sucesso !!!");</script>';
			
			echo '<script>window.location.href="registra.php";</script>';
			}
}

$tmpall = "";
$allSis = new request();
$allSis->openSistema("$tmpall");
$countAll = count($allSis->sis_id);
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>Untitled Document</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>

<body>
<form name="form1" method="post" action="registra.php">
  <table width="90%" border="0" cellspacing="0" cellpadding="0">
    <tr align="center">
      <td colspan="5"><strong>Incluir Sistema </strong></td>
    </tr>
    <tr>
      <td width="1%">&nbsp;</td>
      <td width="20%">&nbsp;</td>
      <td width="56%">&nbsp;</td>
      <td width="21%">&nbsp;</td>
      <td width="2%">&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>Nome Sistema:</td>
      <td><input type="text" name="text_nome"></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>Descricao:</td>
      <td colspan="2"><input name="text_descricao" type="text" size="60"></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>ID sistru </td>
      <td><input type="text" name="text_sistru"></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>Sigla Organiza&ccedil;&atilde;o</td>
      <td><input type="text" name="text_sigla"></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td colspan="2">&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td><input type="submit" name="Submit" value="Registrar"></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td><div align="center"><strong>Sistemas Relacionado no SGD </strong></div></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td bgcolor="#CCCCCC"><strong>Nome Sistema : </strong></td>
      <td align="center" bgcolor="#CCCCCC"><strong>Descri&ccedil;&atilde;o</strong></td>
      <td bgcolor="#CCCCCC"><strong>Sigla Unidade</strong></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="2">TOTAL DE SISTEMAS: <?php echo $countAll ; ?></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td colspan="3">
	 	  
	  <table width="100%" border="1" cellspacing="2" cellpadding="0">
        <?php for($z=0;$z < $countAll;$z++){ ?>
		<tr>
          <td width="27%"><?php echo $allSis->sis_nome[$z]; ?></td>
          <td width="50%"><?php echo $allSis->sis_descricao[$z]; ?></td>
          <td width="23%">
		  <?php 
			$tmporg = "WHERE org.id= '".$allSis->sis_unidade[$z]."' ";
			$orgSistem = new request();
			$orgSistem->openOrganizations($tmporg);
			//echo "<br>";
			echo $orgSistem->org_name[0] ;
		  		  
		  ?>
		  &nbsp;</td>
        </tr>
	   
	   <?php } ?>
      </table>
	  
	  </td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
  </table>
</form>
</body>
</html>

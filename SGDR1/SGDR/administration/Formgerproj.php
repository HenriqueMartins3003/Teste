<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<link rel='stylesheet' href='../themes/default/stylesheet.css' type='text/css' />
<STYLE TYPE="text/css">
<!-
   a:link { color: #333333; text-decoration: none }
   a:hover { color: #333333; text-decoration: none }
   a:visited { color: #333333; text-decoration: none }
->
</STYLE>
<title>Gerencia de usuários</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>
<body>
<?php
//$checkSession = "true"	
$id_usu = $_REQUEST['id_usu'];
include('../includes/library.php');
//$con = OCILogon(MYLOGIN,MYPASSWORD,MYSERVER) or die($strings["error_server"]);
	 $sql = "SELECT DISTINCT(SA.sg_aplicacao) NOME, SA.NO_APLICACAO NAME
		FROM SEGWEB_FNDE.S_APLICACAO SA
		LEFT OUTER JOIN ".MYDATABASE.".PROJECTS SGDP ON SGDP.ID_SISTEMA = SA.nu_seq_aplicacao
		WHERE SGDP.ID_GER_PRO = '".$id_usu."'
		UNION ALL SELECT DISTINCT (SGDS.CO_SISTEMA) NOME, SGDS.NO_SISTEMA NAME FROM ".MYDATABASE.".SISTEMAS SGDS 
		LEFT OUTER JOIN ".MYDATABASE.".PROJECTS SGDP ON SGDP.ID_SISTEMA = SGDS.ID_SISTEMA
                WHERE SGDP.ID_GER_PRO = '".$id_usu."' ORDER BY NOME"; 
	 $result = OCIParse($con, $sql);
	 OCIExecute($result);
	 $row = OCIFetchStatement($result, $res);
	 
	 $sql2 = "SELECT DISTINCT (SU.nu_seq_usuario)ID, SRHC.NO_CADASTRO NAME, SU.ds_e_mail EMAIL
		FROM SEGWEB_FNDE.S_USUARIO SU 
		LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_GRUPO SUG ON SUG.NU_SEQ_USUARIO = SU.nu_seq_usuario
		LEFT OUTER JOIN SEGWEB_FNDE.S_GRUPO SG ON SG.NU_SEQ_GRUPO = SUG.NU_SEQ_GRUPO
		LEFT OUTER JOIN SEGWEB_FNDE.S_APLICACAO SA ON SA.NU_SEQ_APLICACAO = SG.NU_SEQ_APLICACAO
		LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_INTERNO UI ON UI.NU_SEQ_USUARIO = SU.nu_seq_usuario
		LEFT OUTER JOIN RH_FNDE.S_CADASTRO SRHC ON SRHC.NU_SEQ_CADASTRO = UI.NU_SEQ_CADASTRO
		WHERE SU.nu_seq_usuario = '".$id_usu."' AND SUG.ST_ATIVO = 'S'";
            $result2 = OCIParse($con, $sql2);
		    OCIExecute($result2);
		    $row2 = OCIFetchStatement($result2, $res2);
			if($row2 > 0){
				OCIExecute($result2);
				while(OCIFetch($result2)){
					$nome_usu = OCIResult($result2, 'NAME'); 
					$id_us = OCIResult($result2, 'ID');
					$email = OCIResult($result2, 'EMAIL');
				} 
		    }
			
		$sql3 = "SELECT DISTINCT SCL.NU_TELEFONE_UORG TELEFONE, SUO.SG_UNIDADE_ORG LOTACAO
		    FROM SISTRU_ADM.S_UNIDADE_ORG SUO
		        ,SEGWEB_FNDE.S_USUARIO_INTERNO SUI
			,SEGWEB_FNDE.S_USUARIO SU
			,RH_FNDE.S_CADASTRO SC 
			,RH_FNDE.S_CADASTRO_TIPO SCT 
			,RH_FNDE.S_CADASTRO_LOTACAO SCL 
		    WHERE 
		        SUO.NU_SEQ_INTERNO_UORG = SCL.NU_SEQ_INTERNO_UORG
		        AND SU.NU_SEQ_USUARIO = SUI.NU_SEQ_USUARIO
		        AND SC.NU_SEQ_CADASTRO = SUI.NU_SEQ_CADASTRO
		        AND SCT.NU_SEQ_CADASTRO = SC.NU_SEQ_CADASTRO
		        AND SCL.NU_SEQ_CADASTRO_TIPO = SCT.NU_SEQ_CADASTRO_TIPO 
		        AND SCL.DT_SAIDA_LOTACAO IS NULL  
		        AND SU.NU_SEQ_USUARIO = '".$id_usu."'";	
			$result3 = OCIParse($con, $sql3);
		    OCIExecute($result3);
		    $row3 = OCIFetchStatement($result3, $res3);
			if($row3 > 0){
				OCIExecute($result3);
				while(OCIFetch($result3)){
					$lotacao = OCIResult($result3, 'LOTACAO');
					$tel = OCIResult($result3, 'TELEFONE'); 
			 	} 
		    }
			
		$sql4 = "SELECT SAU.sg_unidade_org LOCALIZACAO, SM.phone_work TELEFONE  
		FROM sistru_adm.s_unidade_org SAU, ".MYDATABASE.".MEMBERS SM
		WHERE SM.organization = SAU.nu_seq_interno_uorg
		AND SM.id = '".$id_usu."'";
		
	 $result4 = OCIParse($con, $sql4);
	 OCIExecute($result4);
	 $row4 = OCIFetchStatement($result4, $res4);
	 if($row4 > 0){
	  OCIExecute($result4);
	  while(OCIFetch($result4)){
	       $localizacao = OCIResult($result4, 'LOCALIZACAO');
	       $telatual = OCIResult($result4, 'TELEFONE');
	    }	
	}
	
	$sql5 = "select nu_seq_interno_uorg ID, sg_unidade_org NAME from sistru_adm.s_unidade_org
         order by sg_unidade_org";
	 $result5 = OCIParse($con, $sql5);
	 OCIExecute($result5);
	 $row5 = OCIFetchStatement($result5, $res5);
	 OCIExecute($result5);
	 					
?>	
<TABLE width="570"  height="225" align="CENTER" border="0" cellpadding="0" cellspacing="0">
  <TR>	
    <td class='odd' width="570" height="225"><form name="form1">&nbsp;Nome:&nbsp; 
      <input name="nome" type="text" style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $nome_usu; ?>" size="95" disabled>
		<input type="hidden" name="id_usu" value="<?php echo $id_us; ?>"> 
		 <br><br>
	     &nbsp;e-mail:&nbsp;
	     
    <input name="emailgs" type="text" style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $email; ?>" size="95" disabled>
		<br><br>
		 &nbsp;Lotação:&nbsp; 
    <input name="lotacaogs" type="text" style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $lotacao; ?>" size="12" disabled>
    &nbsp;Localização: &nbsp;
		 <input type="text" name="unigs" style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $localizacao; ?>" size="12" disabled>
          <br><br>
		  &nbsp;Telefone:&nbsp;
    	<input name="tel" type="text"  style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $tel; ?>" size="8" disabled>
    &nbsp;Telefone Atualizado:&nbsp;
    	<input name="tel2" type="text" style="BORDER-RIGHT: #d3d4d4 1px solid; BORDER-TOP: #d9d9d9 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 10px; BACKG ROUND:#ffffff; BORDER-LEFT: #d3d4d4 1px solid; COLOR: #666666; BORDER-BOTTOM: #d3d4d4 1px solid; FONT-STYLE: normal; FONT-FAMILY: Verdana; HEIGHT: 17px; TEXT-ALIGN: left; FONT-VARIANT: normal" value="<?php echo $telatual; ?>" size="8" disabled>
	  <br><br> 
	  <br><br>
<center><a href="FormAltcoord.php?id_usu=<?php echo $id_usu; ?>">| Alterar |</a>&nbsp;&nbsp; <a href="javascript:window.close();">|X| Fechar</a> </center>
<BR>
</TABLE>
<TABLE width="570" align="CENTER" border="1" bordercolor="#c0c0c0" cellpadding="0" cellspacing="0">
       <TR>
         <TD align="CENTER" class='odd'>SIGLA DO SISTEMA</TD>
         <TD align="CENTER" class='odd'>NOME DO SISTEMA</TD>
       </TR>      
        <TR>
	 <?php for($i=0; $i < $row; $i++){ ?>
	 <TR><TD align="CENTER" class='odd'><?php echo $res['NOME'][$i]; ?></TD>
	 <TD align="CENTER" class='odd'><?php echo $res['NAME'][$i]; ?></TD>
	 <?php } ?>	
	</TR>
	</TR>
     
</TABLE>
</body>
</html>
<table width="760" height="195" border="0" align="center" cellpadding="0" cellspacing="0" id="Table_01">
	  <tr>
             <td colspan="2">
                <table width="760" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFCC00">
                   <tr>
                     <td width="600"><img src="../themes/default/images/lg_mec.gif" width="430" height="21"></td>
                     <td width="160"><div align="right"> <!--<img src="../themes/default/images/lg_brasil.gif" width="74" height="21">--></div></td>
                   </tr>
                </table>    
	      </td>
         </tr>
    
	 <tr>
	      <td colspan="2">
			<img src="../themes/default/images/<?php echo $banner_top;?>" width="760" height="138" border="0" alt="" usemap="#Map"></td>
	 </tr>
	 <tr>
	      <td>
	      <img src="../themes/default/images/teste_02.jpg" width="34" height="100%" alt="">
	      </td>
	      <td  width="760" height="31" alt="" style="background-image:url('../themes/default/images/fundo_menu.jpg'); background-repeat:repeat-x; " >
		  
		<?php
if (!$idSession == "") {

	if (($profilSession == 1) || ($profilSession == 3) || ($profilSession == 11)) {
		//if ($profilSession = !10 ){

		include_once "../projects_site/menu.php";
		//}
	} else {
		if (($profilSession == 0) || ($profilSession == 8) || ($profilSession == 10) || ($profilSession == 9) || ($profilSession == 7) || ($profilSession == 6)) {
			include_once "../themes/default/menu_adm.php";
		}

	}
}
?>
		
            </td>
	 </tr>
	 <tr>
	     <td  colspan="2" valign="top"  width="760" height="26" style="background-image:url('../themes/default/images/teste_06.jpg');  background-repeat:repeat-y; ">
	     <?php

?>


	     </td>
	 </tr>
</table>

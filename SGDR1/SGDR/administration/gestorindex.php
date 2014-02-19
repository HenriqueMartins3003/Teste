<HTML>
<HEAD><title>Gerenciamento de usuários</title>
<SCRIPT TYPE="text/javascript">
<!--
function popupform(myform, windowname)
{
if (! window.focus)return true;
window.open('', windowname, 'height=450,width=610,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no');
myform.target=windowname;
return true;
}
//-->
</SCRIPT>
</HEAD>
<BODY>

<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados1(valor1) {
      //verifica se o browser tem suporte a gest
	  try {
         sis1 = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis1 = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis1 = new XMLHttpRequest();
            }
	        catch(exc) {
               sis1 = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis1) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].gsst.options.length = 1;
		 
		 idOpcao  = document.getElementById("opcoes");
		 
		 sis1.open("GET", "gestoresAjax.php", true);
		 
		 sis1.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis1.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis1.readyState == 1) {
			   idOpcao.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis1.readyState == 4 ) {
			   if(sis1.responseXML) {
			      processXMLdoc1(sis1.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao.innerHTML = "Primeiro selecione a localização";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params = "gs="+valor1;
         sis1.send(params);
       }
   }
function processXMLdoc1(obj1){
      //pega a tag cidade
      var dataArray   = obj1.getElementsByTagName("gestor");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;

	        idOpcao.innerHTML = "Gestores:     ";
			
			//cria um novo option dinamicamente  
			var novo = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo.setAttribute("id", "opcoes");
				//atribui um valor
			    novo.value = codigo;
				//atribui um texto
			    novo.text  = descricao;
				//finalmente adiciona o novo elemento
				document.forms[0].gsst.options.add(novo);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhum gestor encontrado');
		idOpcao.innerHTML = "Primeiro selecione uma localização";
		
	  }
	  	    
   }
      
</SCRIPT>

<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados3(valor3) {
      //verifica se o browser tem suporte a gest
	  try {
         sis3 = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis3 = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis3 = new XMLHttpRequest();
            }
	        catch(exc) {
               sis3 = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis3) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].gsst.options.length = 1;
		 
		 idOpcao  = document.getElementById("opcoes");
		 
		 sis3.open("GET", "gestoresAjax2.php", true);
		 
		 sis3.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis3.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis3.readyState == 1) {
			   idOpcao.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis3.readyState == 4 ) {
			   if(sis3.responseXML) {
			      processXMLdoc3(sis3.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao.innerHTML = "Primeiro selecione um sistema";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params = "gs2="+valor3;
         sis3.send(params);
       }
   }
function processXMLdoc3(obj3){
      //pega a tag cidade
      var dataArray   = obj3.getElementsByTagName("gestor");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;

	        idOpcao.innerHTML = "Gestores:     ";
			
			//cria um novo option dinamicamente  
			var novo = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo.setAttribute("id", "opcoes");
				//atribui um valor
			    novo.value = codigo;
				//atribui um texto
			    novo.text  = descricao;
				//finalmente adiciona o novo elemento
				document.forms[0].gsst.options.add(novo);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhum gestor encontrado');
		idOpcao.innerHTML = "Primeiro selecione uma unidade";
		
	  }
	  	    
   }
      
</SCRIPT>

<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados4(valor4) {
      //verifica se o browser tem suporte a gest
	  try {
         sis4 = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis4 = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis4 = new XMLHttpRequest();
            }
	        catch(exc) {
               sis4 = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis4) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].uni.options.length = 1;
		 
		 idOpcao3  = document.getElementById("opcoes3");
		 
		 sis4.open("GET", "unidades.php", true);
		 
		 sis4.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis4.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis4.readyState == 1) {
			   idOpcao3.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis4.readyState == 4 ) {
			   if(sis4.responseXML) {
			      processXMLdoc4(sis4.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao3.innerHTML = "Primeiro selecione a localização";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params4 = "uni="+valor4;
         sis4.send(params4);
       }
   }
function processXMLdoc4(obj4){
      //pega a tag cidade
      var dataArray = obj4.getElementsByTagName("unidade");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo4    =  item.getElementsByTagName("codigo2")[0].firstChild.nodeValue;
			var descricao4 =  item.getElementsByTagName("descricao2")[0].firstChild.nodeValue;

	        idOpcao3.innerHTML = "Localização:     ";
			
			//cria um novo option dinamicamente  
			var novo4 = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo4.setAttribute("id", "opcoes3");
				//atribui um valor
			    novo4.value = codigo4;
				//atribui um texto
			    novo4.text  = descricao4;
				//finalmente adiciona o novo elemento
				document.forms[0].uni.options.add(novo4);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhuma unidade encontrada');
		idOpcao3.innerHTML = "Primeiro selecione um gestor";
		
	  }
	  	    
   }
      
</SCRIPT>

<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados5(valor5) {
      //verifica se o browser tem suporte a gest
	  try {
         sis5 = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis5 = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis5 = new XMLHttpRequest();
            }
	        catch(exc) {
               sis5 = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis5) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].grp.options.length = 1;
		 
		 idOpcao4 = document.getElementById("opcoes4");
		 
		 sis5.open("GET", "gerentes.php", true);
		 
		 sis5.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis5.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis5.readyState == 1) {
			   idOpcao4.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis5.readyState == 4 ) {
			   if(sis5.responseXML) {
			      processXMLdoc5(sis5.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao4.innerHTML = "Primeiro selecione o gestor";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params5 = "grp="+valor5;
         sis5.send(params5);
       }
   }
function processXMLdoc5(obj5){
      //pega a tag cidade
      var dataArray = obj5.getElementsByTagName("gerente");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo5 = item.getElementsByTagName("codigo2")[0].firstChild.nodeValue;
			var descricao5 = item.getElementsByTagName("descricao2")[0].firstChild.nodeValue;

	        idOpcao4.innerHTML = "Gerente de projetos:     ";
			
			//cria um novo option dinamicamente  
			var novo5 = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo5.setAttribute("id", "opcoes4");
				//atribui um valor
			    novo5.value = codigo5;
				//atribui um texto
			    novo5.text  = descricao5;
				//finalmente adiciona o novo elemento
				document.forms[0].grp.options.add(novo5);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhum gerente de projeto encontrado');
		idOpcao4.innerHTML = "Primeiro selecione um gestor";
		
	  }
	  	    
   }
      
</SCRIPT>

<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados6(valor6) {
      //verifica se o browser tem suporte a gest
	  try {
         sis6 = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis6 = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis6 = new XMLHttpRequest();
            }
	        catch(exc) {
               sis6 = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis6) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].anl.options.length = 1;
		 
		 idOpcao5 = document.getElementById("opcoes5");
		 
		 sis6.open("GET", "analistas.php", true);
		 
		 sis6.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis6.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis6.readyState == 1) {
			   idOpcao5.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis6.readyState == 4 ) {
			   if(sis6.responseXML) {
			      processXMLdoc6(sis6.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao5.innerHTML = "Primeiro selecione o gestor";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params6 = "anl="+valor6;
         sis6.send(params6);
       }
   }
function processXMLdoc6(obj6){
      //pega a tag cidade
      var dataArray = obj6.getElementsByTagName("analista");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo6 = item.getElementsByTagName("codigo2")[0].firstChild.nodeValue;
			var descricao6 = item.getElementsByTagName("descricao2")[0].firstChild.nodeValue;

	        idOpcao5.innerHTML = "Analista de relacionamento:     ";
			
			//cria um novo option dinamicamente  
			var novo6 = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo6.setAttribute("id", "opcoes5");
				//atribui um valor
			    novo6.value = codigo6;
				//atribui um texto
			    novo6.text  = descricao6;
				//finalmente adiciona o novo elemento
				document.forms[0].anl.options.add(novo6);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhum analista de relacionamento encontrado');
		idOpcao5.innerHTML = "Primeiro selecione um gestor";
		
	  }
	  	    
   }
      
</SCRIPT>


<SCRIPT LANGUAGE = "JAVASCRIPT">
function Dados(valor) {
      //verifica se o browser tem suporte a gest
	  try {
         sis = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            sis = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               sis = new XMLHttpRequest();
            }
	        catch(exc) {
               sis = null;
            }
         }
      }
  //se tiver suporte gest
	  if(sis) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		document.forms[0].sist.options.length = 1;
		 
		 idOpcao2  = document.getElementById("opcoes2");
		 
		 sis.open("GET", "sistemas.php", true);
		 
		 sis.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 sis.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(sis.readyState == 1) {
			   idOpcao2.innerHTML = "Carregando...";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
            if(sis.readyState == 4 ) {
			   if(sis.responseXML) {
			      processXMLdoc(sis.responseXML);
			   }
			   else {
			       //caso não seja um arquivo XML emite a mensagem abaixo
				   idOpcao2.innerHTML = "Primeiro selecione um Gestor";
				}
            }
         }
		 //passa o código do estado escolhido
	     var params2 = "un="+valor;
         sis.send(params2);
       }
   }
function processXMLdoc(obj){
      //pega a tag cidade
      var dataArray   = obj.getElementsByTagName("sistema");
	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			
			//contéudo dos campos no arquivo XML
			var codigo2    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao2 =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;

	        idOpcao2.innerHTML = "Sistemas:     ";
			
			//cria um novo option dinamicamente  
			var novo1 = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo1.setAttribute("id", "opcoes2");
				//atribui um valor
			    novo1.value = codigo2;
				//atribui um texto
			    novo1.text  = descricao2;
				//finalmente adiciona o novo elemento
				document.forms[0].sist.options.add(novo1);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		alert('Nenhum sistema encontrado');
		idOpcao2.innerHTML = "Primeiro selecione um Gestor";
		
	  }
	  	    
   }
      
</SCRIPT>

<?php 

$checkSession = "true";

include_once ('../includes/library.php');
	
$con = OCILogon(MYLOGIN,MYPASSWORD,MYSERVER) or die($strings["error_server"]);
?>
<form name="InfoGestor" action="Formgest.php" method="GET"  onSubmit="popupform(this, 'join')">
<table width="760" border='0' cellpadding='3' cellspacing='0' class="odd">
  <tr class='odd'> 
    <td height="60" colspan="2" valign='top' class="odd"><div align="center"><strong><br>
        <font size="2"></font></strong><br>
      </div></td>
  </tr><td width="121">
  <tr valign="center"> 
      <td class="odd" colspan="4"> 
      <?php
		$sqlgestor = "SELECT DISTINCT (SU.nu_seq_usuario)ID, SRHC.NO_CADASTRO NAME
			FROM SEGWEB_FNDE.S_USUARIO SU 
			LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_GRUPO SUG ON SUG.NU_SEQ_USUARIO = SU.nu_seq_usuario
			LEFT OUTER JOIN SEGWEB_FNDE.S_GRUPO SG ON SG.NU_SEQ_GRUPO = SUG.NU_SEQ_GRUPO
			LEFT OUTER JOIN SEGWEB_FNDE.S_APLICACAO SA ON SA.NU_SEQ_APLICACAO = SG.NU_SEQ_APLICACAO
			LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_INTERNO UI ON UI.NU_SEQ_USUARIO = SU.nu_seq_usuario
			LEFT OUTER JOIN RH_FNDE.S_CADASTRO SRHC ON SRHC.NU_SEQ_CADASTRO = UI.NU_SEQ_CADASTRO
			WHERE SG.DS_GRUPO = 'GESTOR' AND SUG.ST_ATIVO = 'S' ORDER BY NAME";

					 $resultgestor = OCIParse($con, $sqlgestor);
					 OCIExecute($resultgestor);
					 $rowgs = OCIFetchStatement($resultgestor, $resgs);
					 OCIExecute($resultgestor);
	    	?>
            <select class="odd" name="gsst" size="7" Onchange ="Dados(this.value); Dados4(this.value); Dados5(this.value); Dados6(this.value);">
              <option id="opcoes" value="0">Gestor:</option>
        <?php for($i=0; $i<$rowgs; $i++){ ?>
        <option value="<?php echo $resgs['ID'][$i]; ?>"> <?php echo $resgs['NAME'][$i]; ?> 
        </option>
        <?php } ?>
      </select></td>
 </tr>
  <tr> 
    <td class="odd">&nbsp;</td>
    <td width="211" class="odd">&nbsp;</td>
	<td class="odd">&nbsp;</td>
    <td class="odd">&nbsp;</td>
  </tr>
  <tr> 
     <td class="odd"> 
      <?php
        
            $sqlsis = "SELECT DISTINCT(SA.nu_seq_aplicacao) ID, SA.sg_aplicacao NOME
		FROM SEGWEB_FNDE.S_APLICACAO SA
		LEFT OUTER JOIN SEGWEB_FNDE.S_GESTOR_APLICACAO SGA ON SGA.NU_SEQ_APLICACAO=SA.nu_seq_aplicacao 
		LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_INTERNO SUI ON SUI.NU_SEQ_USUARIO=SGA.NU_SEQ_USUARIO
		LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO SU ON SU.NU_SEQ_USUARIO=SUI.NU_SEQ_USUARIO
		LEFT OUTER JOIN RH_FNDE.S_CADASTRO SC ON SC.NU_SEQ_CADASTRO=SUI.NU_SEQ_CADASTRO
		LEFT OUTER JOIN RH_FNDE.S_CADASTRO_TIPO SCT ON SCT.NU_SEQ_CADASTRO=SC.NU_SEQ_CADASTRO
		LEFT OUTER JOIN RH_FNDE.S_CADASTRO_LOTACAO SCL ON SCL.NU_SEQ_CADASTRO_TIPO=SCT.NU_SEQ_CADASTRO_TIPO
		LEFT OUTER JOIN SISTRU_ADM.S_UNIDADE_ORG SUO ON SUO.NU_SEQ_INTERNO_UORG=SCL.NU_SEQ_INTERNO_UORG
		WHERE SGA.ST_ATIVO='S' 
		AND SCL.DT_SAIDA_LOTACAO IS NULL
                UNION ALL SELECT DISTINCT (ID_SISTEMA) ID, CO_SISTEMA NOME FROM ".MYDATABASE.".SISTEMAS ORDER BY NOME";
	 		$resultsis = OCIParse($con, $sqlsis);
	       	OCIExecute($resultsis);
			$rowsis = OCIFetchStatement($resultsis, $ressis);
			OCIExecute($resultsis);
	
               	    	
	?>
            <select name="sist" class='odd' size="5" Onchange ="Dados3(this.value);">
              <option value="0" selected id="opcoes2">Sistema:</option>
              <?php for($i=0; $i<$rowsis; $i++){ ?>
              <option value="<?php echo $ressis['ID'][$i]; ?>"> <?php echo $ressis['NOME'][$i]; ?> 
              </option>
              <?php } ?>
            </select></td>
	   <td align="center" class="odd">&nbsp;</td>
      <td width="349" class="odd"> 
      <?php
        
            $sqluni = "select nu_seq_interno_uorg ID, sg_unidade_org NAME from sistru_adm.s_unidade_org
                     order by sg_unidade_org";
	 		$resultuni = OCIParse($con, $sqluni);
	       	OCIExecute($resultuni);
			$rowuni = OCIFetchStatement($resultuni, $resuni);
			OCIExecute($resultuni);
	
               	    	
	?>
            <select name="uni" size="5" class='odd' onChange="Dados1(this.value);">
              <option id="opcoes3" value="0">Unidade:</option>
        <?php for($i=0; $i<$rowuni; $i++){ ?>
        <option value="<?php echo $resuni['ID'][$i]; ?>"> <?php echo $resuni['NAME'][$i]; ?> 
        </option>
        <?php } ?>
      </select></td>
  </tr>
  <tr> 
    <td class="odd">&nbsp;</td>
    <td class="odd">&nbsp;</td>
    <td class="odd">&nbsp;</td>
    <td class="odd">&nbsp;</td>
  </tr>
  <tr> 
      <td class="odd"><?php
        
            $sqlgr = "SELECT DISTINCT (SU.nu_seq_usuario)ID, SRHC.NO_CADASTRO NAME
			FROM SEGWEB_FNDE.S_USUARIO SU 
			LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_GRUPO SUG ON SUG.NU_SEQ_USUARIO = SU.nu_seq_usuario
			LEFT OUTER JOIN SEGWEB_FNDE.S_GRUPO SG ON SG.NU_SEQ_GRUPO = SUG.NU_SEQ_GRUPO
			LEFT OUTER JOIN SEGWEB_FNDE.S_APLICACAO SA ON SA.NU_SEQ_APLICACAO = SG.NU_SEQ_APLICACAO
			LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_INTERNO UI ON UI.NU_SEQ_USUARIO = SU.nu_seq_usuario
			LEFT OUTER JOIN RH_FNDE.S_CADASTRO SRHC ON SRHC.NU_SEQ_CADASTRO = UI.NU_SEQ_CADASTRO
			WHERE SG.DS_GRUPO = 'GERENTE PROJETO' AND SUG.ST_ATIVO = 'S' 
            ORDER BY NAME";
	 		$resultgr = OCIParse($con, $sqlgr);
	       	OCIExecute($resultgr);
			$rowgr = OCIFetchStatement($resultgr, $resgr);
			OCIExecute($resultgr);
	
               	    	
	?>
            <select name="grp" class='odd' size="2">
              <option id="opcoes4" value="0">Gerente de Projeto:</option>
        <?php for($i=0; $i<$rowgr; $i++){ ?>
        <option value="<?php echo $resgr['ID'][$i]; ?>"> <?php echo $resgr['NAME'][$i]; ?> 
        </option>
        <?php } ?>
      </select></td>
	
	 <td align="center" class="odd">&nbsp;</td>
           <td class="odd"><?php
        
            $sqlanl = "SELECT DISTINCT (SU.nu_seq_usuario)ID, SRHC.NO_CADASTRO NAME
    			FROM SEGWEB_FNDE.S_USUARIO SU 
     			  LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_GRUPO SUG ON SUG.NU_SEQ_USUARIO = SU.nu_seq_usuario
     			  LEFT OUTER JOIN SEGWEB_FNDE.S_GRUPO SG ON SG.NU_SEQ_GRUPO = SUG.NU_SEQ_GRUPO
     			  LEFT OUTER JOIN SEGWEB_FNDE.S_APLICACAO SA ON SA.NU_SEQ_APLICACAO = SG.NU_SEQ_APLICACAO
     			  LEFT OUTER JOIN SEGWEB_FNDE.S_USUARIO_INTERNO UI ON UI.NU_SEQ_USUARIO = SU.nu_seq_usuario
     			  LEFT OUTER JOIN RH_FNDE.S_CADASTRO SRHC ON SRHC.NU_SEQ_CADASTRO = UI.NU_SEQ_CADASTRO
     			  WHERE SG.NO_GRUPO = 'sgd_analista_relat' AND SUG.ST_ATIVO = 'S' 
                  ORDER BY NAME";
	 		$resultanl = OCIParse($con, $sqlanl);
	       	OCIExecute($resultanl);
			$rowanl = OCIFetchStatement($resultanl, $resanl);
			OCIExecute($resultanl);
	
               	    	
	?>
            <select name="anl" class='odd' size="2">
              <option id="opcoes5" value="0">Analista de Relacionamento:</option>
        <?php for($i=0; $i<$rowanl; $i++){ ?>
        <option value="<?php echo $resanl['ID'][$i]; ?>"> <?php echo $resanl['NAME'][$i]; ?> 
        </option>
        <?php } ?>
      </select></td>
	   </tr>
    <tr>
      <td>
        <input type="submit" name="editar" value="Editar">
         </td>
    </tr>
</table>
</form>
</BODY>
</HTML>
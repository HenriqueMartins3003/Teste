// JavaScript Document
/*
** Application name: SGD
** Last Edit page: 2007-01-22 
** ../themes/default/scriptsax.php
** Authors: luciano / lucianoct188@gmail.com
**
** =============================================================================
**
**               SGD - Managment 
**
** -----------------------------------------------------------------------------
** Please refer to license, copyright, and credits in README.TXT
**
** -----------------------------------------------------------------------------
** FILE: scriptsax.php
**
** DESC: Screen: library file 
**
** HISTORY:
** -----------------------------------------------------------------------------
** TO-DO:
** move to a better login system and authentication (try to db session)
**
** =============================================================================
*/

//

function Dados(combo,xml,opcoes,valor,label,msg,nextFunc) {
      //Verifica se o browser tem suporte a AJAX
 
      var fc = nextFunc;
      var ObjAjax = "";
      
      try {
          ObjAjax = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            ObjAjax = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               ObjAjax = new XMLHttpRequest();
            }
	        catch(exc) {
               ObjAjax = null;
            }
         }
      }
      
      //Se tiver suporte AJAX
      if(ObjAjax) {
		  //deixa apenas o elemento 1 no option, os outros são excluídos
		  if( fc==""){
		  document.getElementById(combo).options.length = 1;
		}else if(fc==1){
		 document.getElementById(combo).value = "";
		}
		  ObjAjax.open("POST", xml, true);
		  ObjAjax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		  ObjAjax.onreadystatechange = function() {
		  
    	  //Enquanto estiver processando... Emite a msg de carregando
		  if(ObjAjax.readyState == 1) {
		  	   document.getElementById(opcoes).innerHTML = "Carregando...";
		  }
		
		  //Após ser processado - chama função processXML que vai varrer os dados
          if(ObjAjax.readyState == 4 ) {
		 		    if(ObjAjax.responseXML) {
		 		
		 		      if( fc==""){	
				         pros = new processXMLcombo(ObjAjax.responseXML,combo,opcoes,msg,nextFunc);
			          }else	if(fc == 1){
			         
			           pros = new processXMLipt(ObjAjax.responseXML,combo,opcoes,msg);
			          
			        	}
			        	
				    }else{
					         //caso não seja um arquivo XML emite a mensagem abaixo
					         document.getElementById(opcoes).innerHTML = 'Primeiro selecione um '+label;
				           }
           }
      }
	
		//passa o código escolhido
		ObjAjax.send("id="+valor);
      }
}
   
function processXMLcombo(obj,combo,opcoes,msg,nextFunc){
	
      //pega a tag do Cabecalho XML
      var dataArray = obj.getElementsByTagName("cabecalho");	   
	  //total de elementos contidos na tag cidade
	  if(dataArray.length > 0) {
	  
	     //percorre o arquivo XML paara extrair os dados
          for(var i = 0 ; i < dataArray.length ; i++) {
             var item = dataArray[i];
	       		document.getElementById(opcoes).innerHTML = msg;
			    
			 var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			 var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;			    

			 var novo = document.createElement("option");
			     //atribui um ID a esse elemento
			     novo.setAttribute("id", "opcoes");
				 //atribui um valor
			     novo.value = codigo;
				 //atribui um texto
			     novo.text  = descricao;
				 //finalmente adiciona o novo elemento
				 document.getElementById(combo).options.add(novo);
		 }
	  }
	  else {
	    //Caso o XML volte vazio, escreve a mensagem abaixo
		alert("Nenhum registro encontrado");
		document.getElementById("opcoes").innerHTML = "Primeiro selecione "+label;
	  } 
	  nextFunc;
}
//

//input

function processXMLipt(obj,combo,opcoes,msg){
 
     //pega a tag nome 
     var dataArray = obj.getElementsByTagName("cabecalho");	
     
	   //total de elementos contidos na tag cidade
     if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
  
      var item = dataArray[0];
			//contéudo dos campos no arquivo XML
			var descricao = item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
		     	
	        if(descricao!=""){
			   
			     	document.getElementById(opcoes).value = descricao;
			     }else{
			     	document.getElementById(opcoes).value = "";
		
			     }
	
		 
	    }else{
	    //caso o XML volte vazio, printa a mensagem abaixo
			document.getElementById(opcoes).value = "";		
	    }
	  	    
 }
//

function pro(valor,local) {
      var loc = local;
	
	  //verifica se o browser tem suporte a gest
if(loc == "0" ){	 
	  try {
         gestt = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            gestt = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               gestt = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para o uso do gest");
               gestt = null;
            }
         }
      }

  //se tiver suporte gest
	  if(gestt) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		 document.forms[0].select2.options.length = 1;
		 // alert('oi'+valor+"local-"+loc);
		 //idOpcao  = document.getElementById("sBann");
		 idOpcao2  = document.getElementById("sel_usu");
		 
		 gestt.open("GET", "recursos.php", true);
		
		 gestt.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 gestt.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(gestt.readyState == 1) {
			   idOpcao2.innerHTML = "Carregando...!";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
					if(gestt.readyState == 4 ) {
					   if(gestt.responseXML) {
					   
						  proXML(gestt.responseXML);
						
					     //idOpcao2.innerHTML = "Sucesso!";
					   } else {
						   //caso não seja um arquivo XML emite a mensagem abaixo
						  idOpcao2.innerHTML = "Sem Usuário!";
							 }
					}
         }

		 //passa o código , tipo usuario
	     var params = "uni="+valor;
       gestt.send(params);
      }
 } 	  
}
//
function proXML(obj){
      //pega a tag cidade
      var dataArray   = obj.getElementsByTagName("gestor");
	  //total de elementos contidos na tag cidade

	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
  
		 for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			//contéudo dos campos no arquivo XML
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			     
	         idOpcao2.innerHTML = "Selecione o Usuário";
			
			//cria um novo option dinamicamente  
			var novo = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo.setAttribute("id", "sel_usu");
				//atribui um valor
			    novo.value = codigo;
				//atribui um texto
			    novo.text  = descricao;
				//finalmente adiciona o novo elemento
				document.forms[0].select2.options.add(novo);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		idOpcao2.innerHTML = "Sem Usuário";
		
	  }
	  	    
   }
   
   // 
   
  //demandas 
  
  function damandas(valor,local) {
      var loc = local;
	
	  //verifica se o browser tem suporte a gest
if(loc == "0" ){	 
	  try {
         gestt = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            gestt = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               gestt = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para o uso do gest");
               gestt = null;
            }
         }
      }

  //se tiver suporte gest
	  if(gestt) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		 document.forms[0].subject.value = "";
		  
		 //idOpcao  = document.getElementById("sBann");
		 idOpcao2  = document.getElementById("subject");
		 idOpcao3  = document.getElementById("desc");
		 
		 gestt.open("GET", "demandagerente.php", true);
		
		 gestt.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 gestt.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(gestt.readyState == 1) {
			   //idOpcao2.innerHTML = "Carregando...!";
			  idOpcao2.value = "Carregando...!";
			  
			   }
			//após ser processado - chama função processXML que vai varrer os dados
					if(gestt.readyState == 4 ) {
					   if(gestt.responseXML) {
					   
						  demandaXML(gestt.responseXML);
						
					     //idOpcao2.value = "Sucesso!";
					   } else {
						   //caso não seja um arquivo XML emite a mensagem abaixo
						  idOpcao2.value = "Sem Usuário!";
							 }
					}
         }

		 //passa o código , tipo usuario
	     var params = "uni="+valor;
       gestt.send(params);
      }
 } 	  
}
//

function demandaXML(obj){
      //pega a tag cidade
      var dataArray   = obj.getElementsByTagName("gestor");
	  //total de elementos contidos na tag cidade

	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
  
		 for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			//contéudo dos campos no arquivo XML
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			var gerente =  item.getElementsByTagName("gerente")[0].firstChild.nodeValue;     
	        if(gerente!=""){
			idOpcao2.value = gerente;
			}else{
			idOpcao2.value = "";
			}
			idOpcao3.innerHTML = descricao;
			
			
			/*
			//cria um novo option dinamicamente  
			var novo = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo.setAttribute("id", "sel_usu");
				//atribui um valor
			    novo.value = codigo;
				//atribui um texto
			    novo.text  = descricao;
				//finalmente adiciona o novo elemento
				document.forms[0].select2.options.add(novo);
				*/
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		idOpcao2.value = "";
		
	  }
	  	    
   }

//
function recursos(id,ativ,hora,data,recurso,fase){
	
 var idOpcao2  = document.getElementById("ativi");
//alert("feito:"+id +"-"+ ativ +"-"+hora+"-"+data+"-"+ recurso +"-"+ fase );
//verifica
if(ativ > 0){
	
	try {
         gestt = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            gestt = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               gestt = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para o uso do gest");
               gestt = null;
            }
         }
      }

  //se tiver suporte gest
	  if(gestt) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		 //document.forms[0].subject.value = "";
		  
		 //idOpcao  = document.getElementById("sBann");
		
		// idOpcao3  = document.getElementById("desc");
		 
		 gestt.open("GET", "insrecursoprojeto.php", true);
		
		 gestt.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 gestt.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(gestt.readyState == 1) {
			   idOpcao2.innerHTML = "Carregando...!";
			   //idOpcao2.value = "Carregando...!";
			  
			   }
			   //após ser processado - chama função processXML que vai varrer os dados
					if(gestt.readyState == 4 ) {
					   if(gestt.responseXML) {
					   
						  recursosXML(gestt.responseXML);
						
					   // idOpcao2.innerHTML = "...!";
					   } else {
						  //caso não seja um arquivo XML emite a mensagem abaixo
						  idOpcao2.innerHTML = "Sem Usuário!";
							 }
					}
         }

		 //passa o código , tipo usuario
	     var params = "ativ="+ativ+"&id="+id+"&hora="+hora+"&data="+data+"&recurso="+recurso+"&fase="+fase;
       gestt.send(params);
      }

//fim verifica
}else{ 
alert('Selecione uma Atividade!');


}

	} 
	
	function recursosXML(obj){
      //pega a tag cidade
      var dataArray   = obj.getElementsByTagName("recurso");
	
	  //total de elementos contidos na tag cidade
    idOpcao2  = document.getElementById("ativi");
	  if(dataArray.length >= 0) {
	     //percorre o arquivo XML paara extrair os dados
  
		 for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			//contéudo dos campos no arquivo XML
			var acao    =  item.getElementsByTagName("acao")[0].firstChild.nodeValue;
			var status =  item.getElementsByTagName("status")[0].firstChild.nodeValue;
			var data1 =  item.getElementsByTagName("data")[0].firstChild.nodeValue;
			var datars =  item.getElementsByTagName("datars")[0].firstChild.nodeValue;
			var horas =  item.getElementsByTagName("horas")[0].firstChild.nodeValue;
			var projeto =  item.getElementsByTagName("projeto")[0].firstChild.nodeValue;
			var recpro =  item.getElementsByTagName("recpro")[0].firstChild.nodeValue;
			var diaesp =  item.getElementsByTagName("diaesp")[0].firstChild.nodeValue;
			var query =  item.getElementsByTagName("query")[0].firstChild.nodeValue;
			
			
	        if(status == 1){
				//alert(projeto+"--tes:"+recpro+"data1--"+data1+" --diaesp"+diaesp+" -datars:"+datars);
			idOpcao2.innerHTML = " Registrado atividade com Sucesso  "+data1;
			//document.getElementById('cp').value=""; 
			//document.getElementById("cp").style.display='none'; 
			//document.forms.[0].cp.value="";
			
			document.getElementById(datars).style.display=''; 
			document.getElementById(datars).innerHTML = "<a href='../calendar/recursocalendar.php?id="+ projeto +"&dateEnreg="+ recpro+"&type=calendDetail&dateCalend="+datars+"' class='calendar-broadcast-todo-event'><b>"+projeto+"&nbsp;-&nbsp;"+horas+"h</b></a>";
			document.getElementById("zzz"+diaesp).style.display='none'; 
			
			//data1+""+projeto +"&nbsp;"+horas;
			}else{
			idOpcao2.innerHTML = "Não registrado na data -"+data1;
			}
			//idOpcao3.innerHTML = descricao;
			//alert(dataArray.length+"--tes:"+status);
			
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		idOpcao2.innerHTML = " ";
		
	  }
	  	    
   }
//

function atividade(valor) {

	  //verifica se o browser tem suporte a gest
 
	 try {
         gestt = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            gestt = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               gestt = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para o uso do gest");
               gestt = null;
            }
         }
      }
	  
    //alert(valor);

  //se tiver suporte gest
	  if(gestt) {
	     //deixa apenas o elemento 1 no option, os outros são excluídos
		 document.forms[0].selectatv.options.length = 1;
		
		 //idOpcao  = document.getElementById("sBann");
		 idOpcao2  = document.getElementById("sel_atv");
		 
		 gestt.open("GET", "atividade.php", true);
		
		 gestt.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		 
		 gestt.onreadystatechange = function() {
            //enquanto estiver processando...emite a msg de carregando
			if(gestt.readyState == 1) {
			   idOpcao2.innerHTML = "Carregando...!";
			   }
			//após ser processado - chama função processXML que vai varrer os dados
					if(gestt.readyState == 4 ) {
					   if(gestt.responseXML) {
					   
						  atividadeXML(gestt.responseXML);
						
					     //idOpcao2.innerHTML = "Sucesso!";
					   } else {
						   //caso não seja um arquivo XML emite a mensagem abaixo
						  idOpcao2.innerHTML = "Sem Atividade!";
							 }
					}
         }

		 //passa o código , tipo usuario
	     var params = "uni="+valor;
       gestt.send(params);
      }
 //} 	  
}
//
//
function atividadeXML(obj){
      //pega a tag cidade
      var dataArray   = obj.getElementsByTagName("atividade");
	  //total de elementos contidos na tag cidade

	  if(dataArray.length > 0) {
	     //percorre o arquivo XML paara extrair os dados
  
		 for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			//contéudo dos campos no arquivo XML
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			     
	         idOpcao2.innerHTML = "Selecione a Atividade";
			
			//cria um novo option dinamicamente  
			var novo = document.createElement("option");
			    //atribui um ID a esse elemento
			    novo.setAttribute("id", "sel_atv");
				//atribui um valor
			    novo.value = codigo;
				//atribui um texto
			    novo.text  = descricao;
				//finalmente adiciona o novo elemento
				document.forms[0].selectatv.options.add(novo);
				
				
		 }
	  }
	  else {
	    //caso o XML volte vazio, printa a mensagem abaixo
		idOpcao2.innerHTML = "Sem Atividade";
		
	  }
	  	    
   }
   
   //       
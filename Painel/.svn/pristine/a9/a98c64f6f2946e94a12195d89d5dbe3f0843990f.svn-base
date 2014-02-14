// JavaScript Document

function Esvazia(valor_campo){
   
if (valor_campo.value == valor_campo.defaultValue)
	valor_campo.value='';
}

function Padrao(valor_campo){

if (valor_campo.value == '')
	valor_campo.value=valor_campo.defaultValue;
}

// arrendondar os cantos das div's
//DD_roundies.addRule('div.containerContentMenu', '3px', true);
//DD_roundies.addRule('div.containerInside', '3px', true);
//DD_roundies.addRule('div#titleMNPainel', '3px', true);
//DD_roundies.addRule('div#titleMNCadastros', '3px 3px 0px 0px', true);
//DD_roundies.addRule('div#actMenuOpt', '0px 0px 3px 3px', true);
//DD_roundies.addRule('div#titleMNMailingHandler', '3px 3px 0px 0px', true);
//DD_roundies.addRule('div#actMenuMH', '0px 0px 3px 3px', true);
//DD_roundies.addRule('div.titleBox', '3px 3px 0px 0px', true);
//DD_roundies.addRule('div.titleFilter', '3px 3px 0px 0px', true);
//DD_roundies.addRule('div.containerFilter', '0px 0px 3px 3px', true);
//DD_roundies.addRule('div.contentOptions', '3px', true);
//DD_roundies.addRule('div.contentBox', '0px 0px 3px 3px', true);

//// actions menu nav
//$(document).ready(function(){

//    // pageload
//    //$('#actMenuOpt').hide();
//        
//    
//    // actions ADD
//    $('#actAdd').click(function(){
//        
//        $('#actMenuOpt').slideToggle(150);
//          
//    });
//    
//    $('#actMH').click(function(){
//        
//        $('#actMenuMH').slideToggle(150);
//          
//    });
//    
//    

//});


function MM_formatoDigitos(e, src, mask) {
    if (window.event) { _TXT = e.keyCode; }
    else if (e.which) { _TXT = e.which; }
    if (_TXT > 47 && _TXT < 58) {
        var i = src.value.length; var saida = mask.substring(0, 1); var texto = mask.substring(i)
        if (texto.substring(0, 1) != saida) { src.value += texto.substring(0, 1); }
        return true;
    } else {
        if (_TXT != 8) { return false; }
        else { return true; }
    }
}

function stopTabCheck(nomeCampo)
{ checarTabulacao = false; }

function startTabCheck()
{ checarTabulacao = true; }


function exibeValor(nomeCampo, lenCampo, controle) {
    if ((nomeCampo.value.length == lenCampo) && (checarTabulacao)) {
        var i = 0;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if (document.forms[0].elements[i].name == nomeCampo.name) {
                while ((i + 1) < document.forms[0].elements.length) {
                    if (document.forms[0].elements[i + 1].type != "hidden") {
                        document.forms[0].elements[i + 1].focus();
                        break;
                    }
                    i++;
                }
                checarTabulacao = false;
                break;
            }
        }
    }
}
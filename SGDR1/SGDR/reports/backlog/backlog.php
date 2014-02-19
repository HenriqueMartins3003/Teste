<?php
include ("../src/jpgraph.php");
include ("../src/jpgraph_line.php");

$aberta = array(20,15,23,15);
$concluida = array(180,9,42,8);
$bklog = array(1,2,2,3);

$mes = array("JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ");
// Setup the graph
$graph = new Graph(600,400);
$graph->SetMarginColor('white');
$graph->SetScale("textlin");
$graph->SetFrame(false);
$graph->SetMargin(30,30,30,30);

$graph->title->Set('Gráfico de Back Log');


$graph->yaxis->HideZeroLabel();
$graph->ygrid->SetFill(true,'#EFEFEF@0.9','#BBCCFF@0.9');
$graph->xgrid->Show();

$graph->xaxis->SetTickLabels($mes);

// Create the first line
$p1 = new LinePlot($aberta);
$p1->SetColor("navy");
$p1->SetLegend('Abertas');
$graph->Add($p1);

// Create the second line
$p2 = new LinePlot($concluida);
$p2->SetColor("orange");
$p2->SetLegend('Concluídas');
$graph->Add($p2);

// Create the third line
$p3 = new LinePlot($bklog);
$p3->SetColor("red");
$p3->SetLegend('Back Log');
$graph->Add($p3);

$graph->legend->SetShadow('#EFEFEF@0.9',0.5);
$graph->legend->SetPos(0.8,0.0,'center','top');
$graph->legend->SetColor('black'); 
$graph->legend->SetFillColor('#EFEFEF@0.5');
$graph->legend->SetFrameWeight(0); 

// Output line
$graph->Stroke();

?>

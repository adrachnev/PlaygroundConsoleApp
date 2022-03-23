﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using WpfApp1.Models;

namespace WpfApp1
{
    public class TestDataContext
    {
        string xaml1 = "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-EP-M12\" Width=\"54\" Height=\"186.002\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"Body\" IsHitTestVisible=\"False\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"101.002\"><Path.Data><PathGeometry Figures=\"M0 79c0-.037 0-.072 0-.107V0H54V79h0V79c0 3.313-12.086 6-27 6S0 82.314 0 79Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 101V6C0 2.686 12.088 0 27 0S54 2.686 54 6v95Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"42.096\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"44.217\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"46.47\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"48.723\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"51.009\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"34.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"10.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"TP2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"32.0\" Canvas.Top=\"106.0\" /><Ellipse Tag=\"TP1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"8.0\" Canvas.Top=\"106.0\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF21\" attachedProperties:SuiteProps.ConnectorName=\"XF21\" attachedProperties:SuiteProps.TranslateTransformX=\"33.996\" attachedProperties:SuiteProps.TranslateTransformY=\"134.0\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"33.996\" Canvas.Top=\"134.0\" /></Canvas></Canvas><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"9.996\" attachedProperties:SuiteProps.TranslateTransformY=\"134.0\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"9.996\" Canvas.Top=\"134.0\" /></Canvas></Canvas></Canvas><Canvas Tag=\"DIL Switches\" IsHitTestVisible=\"False\"><Rectangle Tag=\"Cover\" Width=\"54\" Height=\"17\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0\" Canvas.Top=\"83\" /><Path Tag=\"Switches\" Fill=\"#FFB6BEC6\" Canvas.Left=\"-24712\" Canvas.Top=\"-24741\"><Path.Data><PathGeometry Figures=\"M24729 24838a5 5 0 0 1 0-10h21a5 5 0 0 1 0 10Z\" /></Path.Data></Path></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Rectangle Tag=\"LED_TP2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"72\" /><Rectangle Tag=\"LED_TP1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"72\" /><Rectangle Tag=\"LED_MS\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"63\" /><Rectangle Tag=\"LED_NS\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"63\" /><Rectangle Tag=\"LED_MT\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"47\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"47\" /><Rectangle Tag=\"LED_SD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"38\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"38\" /></Canvas></Canvas>";
        string xaml2 = "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M12\" Width=\"33.005\" Height=\"186\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"130\"><Path.Data><PathGeometry Figures=\"M0 52.048c0-.024 0-.048 0-.071V0H33V52.044h0v0C33 54.231 25.614 56 16.5 56S0 54.231 0 52.048Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 130V3.722H.029C.531 1.646 7.713 0 16.5 0s15.97 1.646 16.472 3.722H33V130Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21.102\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.223\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.476\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.729\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"30.015\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.0\" Canvas.Top=\"157.0\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_7\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_6\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_5\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_4\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"23\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"23\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"106.5\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"81.5\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"3.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas></Canvas></Canvas>";
        string xaml3 = "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M8_Compact\" Width=\"33.001\" Height=\"110\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I Compact I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"79\"><Path.Data><PathGeometry Figures=\"M0 27V0H33V27c0 2.21-7.387 4-16.5 4S0 29.21 0 27Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 79V4C0 1.791 7.387 0 16.5 0S33 1.791 33 4V79Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.121\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.374\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.627\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"29.913\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"82.5\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"71\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"71\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"46\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"46\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"21\" /><Rectangle Tag=\"LED_Unused\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"21\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"32.5\" /><Ellipse Tag=\"X0\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"82.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"82.5\" /></Canvas></Canvas></Canvas></Canvas>";
        string xaml4 = "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M12\" Width=\"33.005\" Height=\"186\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"130\"><Path.Data><PathGeometry Figures=\"M0 52.048c0-.024 0-.048 0-.071V0H33V52.044h0v0C33 54.231 25.614 56 16.5 56S0 54.231 0 52.048Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 130V3.722H.029C.531 1.646 7.713 0 16.5 0s15.97 1.646 16.472 3.722H33V130Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21.102\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.223\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.476\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.729\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"30.015\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.0\" Canvas.Top=\"157.0\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_7\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_6\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_5\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_4\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"23\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"23\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"106.5\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"81.5\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"3.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas></Canvas></Canvas>";

        public TestDataContext() 
        {
            var list = new List<Module> { 
                new Module(xaml1)  { OrderCode = "CPX-AP-I-EP-M12", Name="CPX-AP-I-EP-M12" }, 
                new Module(xaml2) { OrderCode = "CPX-AP-I-M12" , Name = "CPX-AP-I-M12"},
                new Module(xaml3)  { OrderCode = "CPX-AP-I-M8_Compact" , Name="CPX-AP-I-M8_Compact"},
                new Module(xaml4) { OrderCode = "CPX-AP-I-M12" , Name = "CPX-AP-I-M12"},
            };

            var items = new List<CatalogItem> {
                new CatalogItem (xaml1)  { OrderCode = "CPX-AP-I-EP-M12" },
                new CatalogItem (xaml2){ OrderCode = "CPX-AP-I-M12" },
                new CatalogItem  (xaml3){ OrderCode = "CPX-AP-I-M8_Compact" },
                new CatalogItem (xaml4){ OrderCode = "CPX-AP-I-M12" },
            };

            Devices = new ObservableCollection<Module>(list);

            Devices.CollectionChanged += Devices_CollectionChanged;
            
            CatalogItems = new ObservableCollection<CatalogItem>(items);
            AddDevice = new BaseCommand(this);
            PasteDevice = new BaseCommand(this);
            DoubleClickDevice = new BaseCommand(this);
            ModuleNameEditEndingCommand = new BaseCommand();
        }

        

        private void Devices_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(string.Format("e.Action: {0}", e.Action));
            Console.WriteLine(string.Format("e.OldStartingIndex: {0}, e.NewStartingIndex: {1}", e.OldStartingIndex, e.NewStartingIndex));
            
        }

        #region Terminal dependency properties
        public ICommand DoubleClickDevice { get; set; }
        public ICommand PasteDevice { get; set; }        
        public ObservableCollection<Module> Devices { get; set; }        
        public Module  SelectedDevice { get; set; }
        #endregion

        public ObservableCollection<CatalogItem> CatalogItems { get; set; }

        public DragHandler DragHandler { get; set; }
        public ICommand AddDevice { get; set; }

        public ICommand ModuleNameEditEndingCommand { get; set; }

        int counter = 0;
        public void Add() 
        {
            counter++;
           Devices.Add(new Module(xaml1) { OrderCode = "CPX-AP-I-EP-M12 " + counter });
        }
    }

    
    

    public class BaseCommand : ICommand
    {

        private TestDataContext vm;
        public BaseCommand(TestDataContext vm)
        {
            this.vm = vm;
        }
        public BaseCommand() { }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            
        }

        public event EventHandler CanExecuteChanged;
    }

    
}

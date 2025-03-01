﻿using Festo.Theme.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Festo.Suite.Design.AttachedProperties;
using WpfApp1.Models;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TestDataContext
    {
        private int _counter;

        private int counter;

        private readonly string xaml1 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-EP-M12\" Width=\"54\" Height=\"186.002\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"Body\" IsHitTestVisible=\"False\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"101.002\"><Path.Data><PathGeometry Figures=\"M0 79c0-.037 0-.072 0-.107V0H54V79h0V79c0 3.313-12.086 6-27 6S0 82.314 0 79Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 101V6C0 2.686 12.088 0 27 0S54 2.686 54 6v95Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"42.096\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"44.217\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"46.47\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"48.723\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"51.009\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"34.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"10.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"TP2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"32.0\" Canvas.Top=\"106.0\" /><Ellipse Tag=\"TP1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"8.0\" Canvas.Top=\"106.0\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF21\" attachedProperties:SuiteProps.ConnectorName=\"XF21\" attachedProperties:SuiteProps.TranslateTransformX=\"33.996\" attachedProperties:SuiteProps.TranslateTransformY=\"134.0\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"33.996\" Canvas.Top=\"134.0\" /></Canvas></Canvas><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"9.996\" attachedProperties:SuiteProps.TranslateTransformY=\"134.0\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"9.996\" Canvas.Top=\"134.0\" /></Canvas></Canvas></Canvas><Canvas Tag=\"DIL Switches\" IsHitTestVisible=\"False\"><Rectangle Tag=\"Cover\" Width=\"54\" Height=\"17\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0\" Canvas.Top=\"83\" /><Path Tag=\"Switches\" Fill=\"#FFB6BEC6\" Canvas.Left=\"-24712\" Canvas.Top=\"-24741\"><Path.Data><PathGeometry Figures=\"M24729 24838a5 5 0 0 1 0-10h21a5 5 0 0 1 0 10Z\" /></Path.Data></Path></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Rectangle Tag=\"LED_TP2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"72\" /><Rectangle Tag=\"LED_TP1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"72\" /><Rectangle Tag=\"LED_MS\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"63\" /><Rectangle Tag=\"LED_NS\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"63\" /><Rectangle Tag=\"LED_MT\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"47\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"47\" /><Rectangle Tag=\"LED_SD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"47.994\" Canvas.Top=\"38\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"38\" /></Canvas></Canvas>";

        private readonly string xaml2 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M12\" Width=\"33.005\" Height=\"186\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"130\"><Path.Data><PathGeometry Figures=\"M0 52.048c0-.024 0-.048 0-.071V0H33V52.044h0v0C33 54.231 25.614 56 16.5 56S0 54.231 0 52.048Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 130V3.722H.029C.531 1.646 7.713 0 16.5 0s15.97 1.646 16.472 3.722H33V130Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21.102\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.223\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.476\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.729\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"30.015\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.0\" Canvas.Top=\"157.0\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_7\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_6\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_5\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_4\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"23\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"23\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"106.5\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"81.5\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"3.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas></Canvas></Canvas>";

        private readonly string xaml3 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M8_Compact\" Width=\"33.001\" Height=\"110\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I Compact I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"79\"><Path.Data><PathGeometry Figures=\"M0 27V0H33V27c0 2.21-7.387 4-16.5 4S0 29.21 0 27Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 79V4C0 1.791 7.387 0 16.5 0S33 1.791 33 4V79Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.121\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.374\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.627\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"29.913\" Canvas.Top=\"14\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"82.5\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"71\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"71\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"46\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"46\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"21\" /><Rectangle Tag=\"LED_Unused\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"21\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"32.5\" /><Ellipse Tag=\"X0\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"82.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"82.5\" /></Canvas></Canvas></Canvas></Canvas>";

        private readonly string xaml4 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-I-M12\" Width=\"33.005\" Height=\"186\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-I I/O Module Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Body\"><Path Tag=\"Bottom\" Fill=\"#FFD8DCE1\" Canvas.Left=\"0.001\" Canvas.Top=\"130\"><Path.Data><PathGeometry Figures=\"M0 52.048c0-.024 0-.048 0-.071V0H33V52.044h0v0C33 54.231 25.614 56 16.5 56S0 54.231 0 52.048Z\" /></Path.Data></Path><Path Tag=\"Top\" Fill=\"#FFE5E8EB\" Canvas.Left=\"-0.001\" Canvas.Top=\"0\"><Path.Data><PathGeometry Figures=\"M0 130V3.722H.029C.531 1.646 7.713 0 16.5 0s15.97 1.646 16.472 3.722H33V130Z\" /></Path.Data></Path><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"21.102\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M.066 1.943A.066.066 0 0 1 0 1.878V.065A.066.066 0 0 1 .066 0H1.922a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.066.066 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.789a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065v.647a.066.066 0 0 1-.066.065Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"23.223\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .066 0H2.054a.066.066 0 0 1 .066.065V.324a.066.066 0 0 1-.066.065H.6A.065.065 0 0 0 .53.454V.713A.066.066 0 0 0 .6.778H1.922a.066.066 0 0 1 .066.065V1.1a.065.065 0 0 1-.066.064H.6a.066.066 0 0 0-.066.065V1.49A.066.066 0 0 0 .6 1.555H2.054a.066.066 0 0 1 .066.065v.259a.066.066 0 0 1-.066.065H.066A.066.066 0 0 1 0 1.879Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"25.476\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .778a.393.393 0 0 0 .4.388h1.06a.131.131 0 0 1 .133.13v.129a.131.131 0 0 1-.133.13H.6A.066.066 0 0 1 .53 1.49a.066.066 0 0 0-.066-.065h-.4A.066.066 0 0 0 0 1.49v.065a.393.393 0 0 0 .4.389H1.723a.393.393 0 0 0 .4-.389V1.166a.393.393 0 0 0-.4-.388H.663A.131.131 0 0 1 .53.648V.518A.131.131 0 0 1 .663.389h.861a.065.065 0 0 1 .067.065.065.065 0 0 0 .066.065h.4A.066.066 0 0 0 2.12.454V.389A.394.394 0 0 0 1.723 0H.4A.393.393 0 0 0 0 .389Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"27.729\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M0 .065A.066.066 0 0 1 .067 0H2.054a.066.066 0 0 1 .067.065V.324a.066.066 0 0 1-.067.065H1.392a.065.065 0 0 0-.066.065V1.878a.066.066 0 0 1-.067.065h-.4A.066.066 0 0 1 .8 1.878V.454A.065.065 0 0 0 .729.389H.067A.066.066 0 0 1 0 .324V.065Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"30.015\" Canvas.Top=\"16.336\"><Path.Data><PathGeometry Figures=\"M1.7 1.949H.391a.391.391 0 0 1-.36-.238A.386.386 0 0 1 0 1.559V.39A.388.388 0 0 1 .115.114.39.39 0 0 1 .391 0H1.7a.39.39 0 0 1 .391.39V1.559a.39.39 0 0 1-.391.39ZM.652.39A.13.13 0 0 0 .56.428.129.129 0 0 0 .522.52v.909a.13.13 0 0 0 .131.13h.783a.13.13 0 0 0 .131-.13V.52A.129.129 0 0 0 1.527.428.13.13 0 0 0 1.435.39Z\" /></Path.Data></Path></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\"><Ellipse Tag=\"XD2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"20.0\" Canvas.Top=\"157.0\" /><Ellipse Tag=\"XD1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"3.0\" Canvas.Top=\"157.0\" /></Canvas><Canvas Tag=\"LEDs\"><Rectangle Tag=\"LED_7\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_6\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"122\" /><Rectangle Tag=\"LED_5\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_4\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"97\" /><Rectangle Tag=\"LED_3\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_2\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"73\" /><Rectangle Tag=\"LED_1\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_0\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"48\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"27\" Canvas.Top=\"23\" /><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"6\" Fill=\"#FFB6BEC6\" Canvas.Left=\"0\" Canvas.Top=\"23\" /></Canvas></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"106.5\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"81.5\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"56.5\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"14.5\" Canvas.Top=\"32.5\" /></Canvas><Canvas Tag=\"Connectors\"><Canvas Tag=\"XF20\" attachedProperties:SuiteProps.ConnectorName=\"XF20\" attachedProperties:SuiteProps.TranslateTransformX=\"20.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Right\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Right\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"20.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas><Canvas Tag=\"XF10\" attachedProperties:SuiteProps.ConnectorName=\"XF10\" attachedProperties:SuiteProps.TranslateTransformX=\"3.5\" attachedProperties:SuiteProps.TranslateTransformY=\"134.5\" attachedProperties:SuiteProps.ConnectorOutDirection=\"Left\" attachedProperties:SuiteProps.UIType=\"M8\"><Canvas Tag=\"Left\"><Ellipse Tag=\"M8\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FF0091DC\" Stroke=\"#FF0091DC\" StrokeThickness=\"2\" Canvas.Left=\"3.5\" Canvas.Top=\"134.5\" /></Canvas></Canvas></Canvas></Canvas>";

        private readonly string xaml5 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"VABA-S6-1-X5\" Width=\"142\" Height=\"145\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"Spacer\" IsHitTestVisible=\"False\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"140\" Canvas.Left=\"140\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valves\" IsHitTestVisible=\"False\"><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"76\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"73\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"73\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-2\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"93\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-2\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"90\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-2\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"90\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-3\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"110\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-3\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"107\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-3\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"107\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-4\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"127\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-4\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"124\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-4\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"124\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Cut out\"><Path Tag=\"Middle\" Stroke=\"#FFF2F3F5\" StrokeThickness=\"7\" Canvas.Left=\"-208.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path><Path Tag=\"Right\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"1\" Canvas.Left=\"-204.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path><Path Tag=\"Left\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"1\" Canvas.Left=\"-212.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path></Canvas></Canvas><Rectangle Tag=\"Body\" Width=\"72\" Height=\"140\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" IsHitTestVisible=\"False\" /><Canvas Tag=\"Screws\" IsHitTestVisible=\"False\"><Ellipse Tag=\"Screw\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"114\" /><Ellipse Tag=\"Screw-2\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"126\" /><Ellipse Tag=\"Screw-3\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"63\" Canvas.Top=\"114\" /><Ellipse Tag=\"Screw-4\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"63\" Canvas.Top=\"19\" /><Ellipse Tag=\"Screw-5\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"3\" /><Ellipse Tag=\"Screw-6\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"7\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"46\" Canvas.Top=\"10\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"38\" Canvas.Top=\"10\" /></Canvas><Canvas Tag=\"Slot\" IsHitTestVisible=\"False\"><Path Tag=\"Right_Notch\" Fill=\"#FFD8DCE1\" Canvas.Left=\"68.999\" Canvas.Top=\"110.084\"><Path.Data><PathGeometry Figures=\"M0 6.085v49c0 3.793 7 11.093 7 11.093V0S0 1.823 0 6.085Z\" /></Path.Data><Path.RenderTransform><RotateTransform CenterX=\"0\" CenterY=\"0\" Angle=\"180\" /></Path.RenderTransform></Path><Path Tag=\"Left_Notch\" Fill=\"#FFD8DCE1\" Canvas.Left=\"-11813\" Canvas.Top=\"-14960.092\"><Path.Data><PathGeometry Figures=\"M11816 15064.091v-49c0-3.793 7-11.093 7-11.093v66.176S11816 15068.353 11816 15064.091Z\" /></Path.Data></Path><Canvas Tag=\"Frame\"><Rectangle Width=\"53.0\" Height=\"110.0\" StrokeThickness=\"1\" Canvas.Left=\"9.5\" Canvas.Top=\"15.5\" /><Rectangle Width=\"52.0\" Height=\"109.0\" Stroke=\"#FFD8DCE1\" StrokeThickness=\"1\" Canvas.Left=\"9.5\" Canvas.Top=\"15.5\" /></Canvas></Canvas><Rectangle Tag=\"ModulePlaceHolder\" Width=\"50\" Height=\"107\" Canvas.Left=\"11\" Canvas.Top=\"17\" IsHitTestVisible=\"False\" attachedProperties:SuiteProps.TranslateTransformX=\"11\" attachedProperties:SuiteProps.TranslateTransformY=\"17\" attachedProperties:SuiteProps.ModulePlaceHolder=\"guid\" /><Canvas Tag=\"ApAddressPlaceHolder\" IsHitTestVisible=\"False\" attachedProperties:SuiteProps.TranslateTransformX=\"118\" attachedProperties:SuiteProps.TranslateTransformY=\"128\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\"><Rectangle Tag=\"ApAddressPlaceHolder-2\" Width=\"20\" Height=\"8\" Fill=\"#FFFFFFFF\" Canvas.Left=\"118\" Canvas.Top=\"128\" /></Canvas></Canvas>";

        private readonly string xaml6 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-A-12DI4DO-M12-5P\" Width=\"52\" Height=\"107\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-A Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Spacer\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"107\" Canvas.Left=\"50\" Canvas.Top=\"0\" /></Canvas><Rectangle Tag=\"Base\" Width=\"50\" Height=\"107\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" /><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"27.2\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M.091 2.814A.093.093 0 0 1 0 2.72V.094A.093.093 0 0 1 .091 0h2.54a.093.093 0 0 1 .091.094V.469a.092.092 0 0 1-.091.094H.817A.092.092 0 0 0 .726.657v.375a.093.093 0 0 0 .091.094H2.45a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.09.093H.817a.093.093 0 0 0-.091.094V2.72a.093.093 0 0 1-.091.094Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"30.102999999999998\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .091 0H2.813A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094h-2A.092.092 0 0 0 .726.657v.375a.092.092 0 0 0 .091.094H2.631a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.091.093H.817a.093.093 0 0 0-.091.094v.375a.093.093 0 0 0 .091.094h2a.092.092 0 0 1 .091.094V2.72a.093.093 0 0 1-.091.094H.091A.093.093 0 0 1 0 2.72Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"33.188\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 1.126a.553.553 0 0 0 .544.562H2a.185.185 0 0 1 .182.188v.187A.184.184 0 0 1 2 2.252H.816a.093.093 0 0 1-.091-.094.092.092 0 0 0-.09-.094H.09A.092.092 0 0 0 0 2.157v.094a.554.554 0 0 0 .544.563H2.359A.554.554 0 0 0 2.9 2.252V1.688a.553.553 0 0 0-.544-.562H.907A.185.185 0 0 1 .726.938V.751A.184.184 0 0 1 .907.563H2.086a.092.092 0 0 1 .091.094.092.092 0 0 0 .09.094h.545A.092.092 0 0 0 2.9.657V.563A.554.554 0 0 0 2.359 0H.544A.554.554 0 0 0 0 .563Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"36.272\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .092 0H2.812A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094H1.906a.092.092 0 0 0-.09.094V2.72a.093.093 0 0 1-.091.094H1.18a.093.093 0 0 1-.091-.094V.657A.092.092 0 0 0 1 .563H.091A.093.093 0 0 1 0 .469V.094Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"39.402\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M2.322 2.822H.535a.508.508 0 0 1-.208-.044.533.533 0 0 1-.17-.121.565.565 0 0 1-.115-.179A.587.587 0 0 1 0 2.258V.565A.587.587 0 0 1 .042.345.566.566 0 0 1 .157.165.534.534 0 0 1 .327.044.507.507 0 0 1 .535 0H2.322a.509.509 0 0 1 .209.044A.532.532 0 0 1 2.7.165a.565.565 0 0 1 .115.18.589.589 0 0 1 .042.22V2.258a.588.588 0 0 1-.042.22.565.565 0 0 1-.115.179.532.532 0 0 1-.17.121A.509.509 0 0 1 2.322 2.822ZM.893.565A.173.173 0 0 0 .766.62.192.192 0 0 0 .714.753V2.069A.193.193 0 0 0 .766 2.2a.173.173 0 0 0 .127.055H1.965A.173.173 0 0 0 2.091 2.2a.193.193 0 0 0 .052-.133V.753A.192.192 0 0 0 2.091.62.173.173 0 0 0 1.965.565Z\" /></Path.Data></Path></Canvas><Rectangle Tag=\"ApAddressPlaceHolder\" Width=\"20\" Height=\"8\" Canvas.Left=\"28\" Canvas.Top=\"95\" attachedProperties:SuiteProps.TranslateTransformX=\"28\" attachedProperties:SuiteProps.TranslateTransformY=\"95\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\" /></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X7\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"84.0\" /><Ellipse Tag=\"X6\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"84.0\" /><Ellipse Tag=\"X5\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"60.0\" /><Ellipse Tag=\"X4\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"60.0\" /><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"36.0\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"36.0\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"12.0\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"12.0\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Canvas Tag=\"Row 4\"><Rectangle Tag=\"O3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"96\" /><Rectangle Tag=\"O2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"92\" /><Rectangle Tag=\"O1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"88\" /><Rectangle Tag=\"O0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"84\" /></Canvas><Canvas Tag=\"Row 3\"><Rectangle Tag=\"I11\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"72\" /><Rectangle Tag=\"I10\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"68\" /><Rectangle Tag=\"I9\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"64\" /><Rectangle Tag=\"I8\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"60\" /></Canvas><Canvas Tag=\"Row 2\"><Rectangle Tag=\"I7\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"48\" /><Rectangle Tag=\"I6\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"44\" /><Rectangle Tag=\"I5\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"40\" /><Rectangle Tag=\"I4\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"36\" /></Canvas><Canvas Tag=\"Row 1\"><Rectangle Tag=\"I3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"24\" /><Rectangle Tag=\"I2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"20\" /><Rectangle Tag=\"I1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"16\" /><Rectangle Tag=\"I0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"12\" /></Canvas><Canvas Tag=\"Top\"><Rectangle Tag=\"PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"30\" Canvas.Top=\"8\" /><Rectangle Tag=\"MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"8\" /></Canvas></Canvas></Canvas>";

        private readonly string xaml7 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-A-16DI-D-M12-5P\" Width=\"52\" Height=\"107\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-A Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Spacer\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"107\" Canvas.Left=\"50\" Canvas.Top=\"0\" /></Canvas><Rectangle Tag=\"Base\" Width=\"50\" Height=\"107\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" /><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"27.2\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M.091 2.814A.093.093 0 0 1 0 2.72V.094A.093.093 0 0 1 .091 0h2.54a.093.093 0 0 1 .091.094V.469a.092.092 0 0 1-.091.094H.817A.092.092 0 0 0 .726.657v.375a.093.093 0 0 0 .091.094H2.45a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.09.093H.817a.093.093 0 0 0-.091.094V2.72a.093.093 0 0 1-.091.094Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"30.102999999999998\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .091 0H2.813A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094h-2A.092.092 0 0 0 .726.657v.375a.092.092 0 0 0 .091.094H2.631a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.091.093H.817a.093.093 0 0 0-.091.094v.375a.093.093 0 0 0 .091.094h2a.092.092 0 0 1 .091.094V2.72a.093.093 0 0 1-.091.094H.091A.093.093 0 0 1 0 2.72Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"33.188\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 1.126a.553.553 0 0 0 .544.562H2a.185.185 0 0 1 .182.188v.187A.184.184 0 0 1 2 2.252H.816a.093.093 0 0 1-.091-.094.092.092 0 0 0-.09-.094H.09A.092.092 0 0 0 0 2.157v.094a.554.554 0 0 0 .544.563H2.359A.554.554 0 0 0 2.9 2.252V1.688a.553.553 0 0 0-.544-.562H.907A.185.185 0 0 1 .726.938V.751A.184.184 0 0 1 .907.563H2.086a.092.092 0 0 1 .091.094.092.092 0 0 0 .09.094h.545A.092.092 0 0 0 2.9.657V.563A.554.554 0 0 0 2.359 0H.544A.554.554 0 0 0 0 .563Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"36.272\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .092 0H2.812A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094H1.906a.092.092 0 0 0-.09.094V2.72a.093.093 0 0 1-.091.094H1.18a.093.093 0 0 1-.091-.094V.657A.092.092 0 0 0 1 .563H.091A.093.093 0 0 1 0 .469V.094Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"39.402\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M2.322 2.822H.535a.508.508 0 0 1-.208-.044.533.533 0 0 1-.17-.121.565.565 0 0 1-.115-.179A.587.587 0 0 1 0 2.258V.565A.587.587 0 0 1 .042.345.566.566 0 0 1 .157.165.534.534 0 0 1 .327.044.507.507 0 0 1 .535 0H2.322a.509.509 0 0 1 .209.044A.532.532 0 0 1 2.7.165a.565.565 0 0 1 .115.18.589.589 0 0 1 .042.22V2.258a.588.588 0 0 1-.042.22.565.565 0 0 1-.115.179.532.532 0 0 1-.17.121A.509.509 0 0 1 2.322 2.822ZM.893.565A.173.173 0 0 0 .766.62.192.192 0 0 0 .714.753V2.069A.193.193 0 0 0 .766 2.2a.173.173 0 0 0 .127.055H1.965A.173.173 0 0 0 2.091 2.2a.193.193 0 0 0 .052-.133V.753A.192.192 0 0 0 2.091.62.173.173 0 0 0 1.965.565Z\" /></Path.Data></Path></Canvas><Rectangle Tag=\"ApAddressPlaceHolder\" Width=\"20\" Height=\"8\" Canvas.Left=\"28\" Canvas.Top=\"95\" attachedProperties:SuiteProps.TranslateTransformX=\"28\" attachedProperties:SuiteProps.TranslateTransformY=\"95\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\" /></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X7\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"84.0\" /><Ellipse Tag=\"X6\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"84.0\" /><Ellipse Tag=\"X5\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"60.0\" /><Ellipse Tag=\"X4\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"60.0\" /><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"36.0\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"36.0\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"12.0\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"5.0\" Canvas.Top=\"12.0\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Canvas Tag=\"Row 4\"><Rectangle Tag=\"_15\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"96\" /><Rectangle Tag=\"_14\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"92\" /><Rectangle Tag=\"_13\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"88\" /><Rectangle Tag=\"_12\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"84\" /></Canvas><Canvas Tag=\"Row 3\"><Rectangle Tag=\"_11\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"72\" /><Rectangle Tag=\"_10\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"68\" /><Rectangle Tag=\"_9\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"64\" /><Rectangle Tag=\"_8\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"60\" /></Canvas><Canvas Tag=\"Row 2\"><Rectangle Tag=\"_7\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"48\" /><Rectangle Tag=\"_6\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"44\" /><Rectangle Tag=\"_5\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"40\" /><Rectangle Tag=\"_4\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"36\" /></Canvas><Canvas Tag=\"Row 1\"><Rectangle Tag=\"_3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"24\" /><Rectangle Tag=\"_2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"20\" /><Rectangle Tag=\"_1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"16\" /><Rectangle Tag=\"_0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"12\" /></Canvas><Canvas Tag=\"Top\"><Rectangle Tag=\"PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"30\" Canvas.Top=\"8\" /><Rectangle Tag=\"MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"8\" /></Canvas></Canvas></Canvas>";

        private readonly string xaml8 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-A-4IOL-M12\" Width=\"52\" Height=\"107\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-A Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Spacer\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"107\" Canvas.Left=\"50\" Canvas.Top=\"0\" /></Canvas><Rectangle Tag=\"Base\" Width=\"50\" Height=\"107\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" /><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"27.2\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M.091 2.814A.093.093 0 0 1 0 2.72V.094A.093.093 0 0 1 .091 0h2.54a.093.093 0 0 1 .091.094V.469a.092.092 0 0 1-.091.094H.817A.092.092 0 0 0 .726.657v.375a.093.093 0 0 0 .091.094H2.45a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.09.093H.817a.093.093 0 0 0-.091.094V2.72a.093.093 0 0 1-.091.094Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"30.102999999999998\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .091 0H2.813A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094h-2A.092.092 0 0 0 .726.657v.375a.092.092 0 0 0 .091.094H2.631a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.091.093H.817a.093.093 0 0 0-.091.094v.375a.093.093 0 0 0 .091.094h2a.092.092 0 0 1 .091.094V2.72a.093.093 0 0 1-.091.094H.091A.093.093 0 0 1 0 2.72Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"33.188\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 1.126a.553.553 0 0 0 .544.562H2a.185.185 0 0 1 .182.188v.187A.184.184 0 0 1 2 2.252H.816a.093.093 0 0 1-.091-.094.092.092 0 0 0-.09-.094H.09A.092.092 0 0 0 0 2.157v.094a.554.554 0 0 0 .544.563H2.359A.554.554 0 0 0 2.9 2.252V1.688a.553.553 0 0 0-.544-.562H.907A.185.185 0 0 1 .726.938V.751A.184.184 0 0 1 .907.563H2.086a.092.092 0 0 1 .091.094.092.092 0 0 0 .09.094h.545A.092.092 0 0 0 2.9.657V.563A.554.554 0 0 0 2.359 0H.544A.554.554 0 0 0 0 .563Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"36.272\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .092 0H2.812A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094H1.906a.092.092 0 0 0-.09.094V2.72a.093.093 0 0 1-.091.094H1.18a.093.093 0 0 1-.091-.094V.657A.092.092 0 0 0 1 .563H.091A.093.093 0 0 1 0 .469V.094Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"39.402\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M2.322 2.822H.535a.508.508 0 0 1-.208-.044.533.533 0 0 1-.17-.121.565.565 0 0 1-.115-.179A.587.587 0 0 1 0 2.258V.565A.587.587 0 0 1 .042.345.566.566 0 0 1 .157.165.534.534 0 0 1 .327.044.507.507 0 0 1 .535 0H2.322a.509.509 0 0 1 .209.044A.532.532 0 0 1 2.7.165a.565.565 0 0 1 .115.18.589.589 0 0 1 .042.22V2.258a.588.588 0 0 1-.042.22.565.565 0 0 1-.115.179.532.532 0 0 1-.17.121A.509.509 0 0 1 2.322 2.822ZM.893.565A.173.173 0 0 0 .766.62.192.192 0 0 0 .714.753V2.069A.193.193 0 0 0 .766 2.2a.173.173 0 0 0 .127.055H1.965A.173.173 0 0 0 2.091 2.2a.193.193 0 0 0 .052-.133V.753A.192.192 0 0 0 2.091.62.173.173 0 0 0 1.965.565Z\" /></Path.Data></Path></Canvas><Line Tag=\"Line\" X1=\"0\" X2=\"49\" Y1=\"0\" Y2=\"0\" Stroke=\"#FFD8DCE1\" StrokeThickness=\"1\" Canvas.Left=\"0.5\" Canvas.Top=\"29.5\" /><Rectangle Tag=\"ApAddressPlaceHolder\" Width=\"20\" Height=\"8\" Canvas.Left=\"28\" Canvas.Top=\"95\" attachedProperties:SuiteProps.TranslateTransformX=\"28\" attachedProperties:SuiteProps.TranslateTransformY=\"95\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\" /></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X3\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"26.0\" Canvas.Top=\"81.0\" /><Ellipse Tag=\"X2\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"10.0\" Canvas.Top=\"66.0\" /><Ellipse Tag=\"X1\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"26.0\" Canvas.Top=\"48.0\" /><Ellipse Tag=\"X0\" Width=\"14.0\" Height=\"14.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"10.0\" Canvas.Top=\"33.0\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Canvas Tag=\"Right\"><Rectangle Tag=\"PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"10\" /><Rectangle Tag=\"MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"10\" /></Canvas><Canvas Tag=\"Left\"><Rectangle Tag=\"_3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"18\" /><Rectangle Tag=\"_2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"18\" /><Rectangle Tag=\"_1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"14\" /><Rectangle Tag=\"_0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"14\" /></Canvas></Canvas></Canvas>";

        private readonly string xaml9 =
            "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"CPX-AP-A-12DI4DO-M8-4P\" Width=\"52\" Height=\"107\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"CPX-AP-A Base\" IsHitTestVisible=\"False\"><Canvas Tag=\"Spacer\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"107\" Canvas.Left=\"50\" Canvas.Top=\"0\" /></Canvas><Rectangle Tag=\"Base\" Width=\"50\" Height=\"107\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" /><Canvas Tag=\"Festo Logo\"><Path Tag=\"F\" Fill=\"#FF0091DC\" Canvas.Left=\"27.2\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M.091 2.814A.093.093 0 0 1 0 2.72V.094A.093.093 0 0 1 .091 0h2.54a.093.093 0 0 1 .091.094V.469a.092.092 0 0 1-.091.094H.817A.092.092 0 0 0 .726.657v.375a.093.093 0 0 0 .091.094H2.45a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.09.093H.817a.093.093 0 0 0-.091.094V2.72a.093.093 0 0 1-.091.094Z\" /></Path.Data></Path><Path Tag=\"E\" Fill=\"#FF0091DC\" Canvas.Left=\"30.102999999999998\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .091 0H2.813A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094h-2A.092.092 0 0 0 .726.657v.375a.092.092 0 0 0 .091.094H2.631a.092.092 0 0 1 .091.094V1.6a.092.092 0 0 1-.091.093H.817a.093.093 0 0 0-.091.094v.375a.093.093 0 0 0 .091.094h2a.092.092 0 0 1 .091.094V2.72a.093.093 0 0 1-.091.094H.091A.093.093 0 0 1 0 2.72Z\" /></Path.Data></Path><Path Tag=\"S\" Fill=\"#FF0091DC\" Canvas.Left=\"33.188\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 1.126a.553.553 0 0 0 .544.562H2a.185.185 0 0 1 .182.188v.187A.184.184 0 0 1 2 2.252H.816a.093.093 0 0 1-.091-.094.092.092 0 0 0-.09-.094H.09A.092.092 0 0 0 0 2.157v.094a.554.554 0 0 0 .544.563H2.359A.554.554 0 0 0 2.9 2.252V1.688a.553.553 0 0 0-.544-.562H.907A.185.185 0 0 1 .726.938V.751A.184.184 0 0 1 .907.563H2.086a.092.092 0 0 1 .091.094.092.092 0 0 0 .09.094h.545A.092.092 0 0 0 2.9.657V.563A.554.554 0 0 0 2.359 0H.544A.554.554 0 0 0 0 .563Z\" /></Path.Data></Path><Path Tag=\"T\" Fill=\"#FF0091DC\" Canvas.Left=\"36.272\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M0 .094A.093.093 0 0 1 .092 0H2.812A.093.093 0 0 1 2.9.094V.469a.093.093 0 0 1-.091.094H1.906a.092.092 0 0 0-.09.094V2.72a.093.093 0 0 1-.091.094H1.18a.093.093 0 0 1-.091-.094V.657A.092.092 0 0 0 1 .563H.091A.093.093 0 0 1 0 .469V.094Z\" /></Path.Data></Path><Path Tag=\"O\" Fill=\"#FF0091DC\" Canvas.Left=\"39.402\" Canvas.Top=\"1.951\"><Path.Data><PathGeometry Figures=\"M2.322 2.822H.535a.508.508 0 0 1-.208-.044.533.533 0 0 1-.17-.121.565.565 0 0 1-.115-.179A.587.587 0 0 1 0 2.258V.565A.587.587 0 0 1 .042.345.566.566 0 0 1 .157.165.534.534 0 0 1 .327.044.507.507 0 0 1 .535 0H2.322a.509.509 0 0 1 .209.044A.532.532 0 0 1 2.7.165a.565.565 0 0 1 .115.18.589.589 0 0 1 .042.22V2.258a.588.588 0 0 1-.042.22.565.565 0 0 1-.115.179.532.532 0 0 1-.17.121A.509.509 0 0 1 2.322 2.822ZM.893.565A.173.173 0 0 0 .766.62.192.192 0 0 0 .714.753V2.069A.193.193 0 0 0 .766 2.2a.173.173 0 0 0 .127.055H1.965A.173.173 0 0 0 2.091 2.2a.193.193 0 0 0 .052-.133V.753A.192.192 0 0 0 2.091.62.173.173 0 0 0 1.965.565Z\" /></Path.Data></Path></Canvas><Line Tag=\"Line\" X1=\"0\" X2=\"49\" Y1=\"0\" Y2=\"0\" Stroke=\"#FFD8DCE1\" StrokeThickness=\"1\" Canvas.Left=\"0.5\" Canvas.Top=\"29.5\" /><Rectangle Tag=\"ApAddressPlaceHolder\" Width=\"20\" Height=\"8\" Canvas.Left=\"28\" Canvas.Top=\"95\" attachedProperties:SuiteProps.TranslateTransformX=\"28\" attachedProperties:SuiteProps.TranslateTransformY=\"95\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\" /></Canvas><Canvas Tag=\"Auxiliary Interfaces\" IsHitTestVisible=\"False\"><Ellipse Tag=\"X7\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"88.0\" /><Ellipse Tag=\"X6\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"71.0\" /><Ellipse Tag=\"X5\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"54.0\" /><Ellipse Tag=\"X4\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"31.0\" Canvas.Top=\"37.0\" /><Ellipse Tag=\"X3\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"9.0\" Canvas.Top=\"88.0\" /><Ellipse Tag=\"X2\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"9.0\" Canvas.Top=\"71.0\" /><Ellipse Tag=\"X1\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"9.0\" Canvas.Top=\"54.0\" /><Ellipse Tag=\"X0\" Width=\"10.0\" Height=\"10.0\" Fill=\"#FFB6BEC6\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"2\" Canvas.Left=\"9.0\" Canvas.Top=\"37.0\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Canvas Tag=\"Right\"><Rectangle Tag=\"O3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"26\" /><Rectangle Tag=\"O2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"26\" /><Rectangle Tag=\"I11\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"22\" /><Rectangle Tag=\"I10\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"22\" /><Rectangle Tag=\"I7\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"18\" /><Rectangle Tag=\"I6\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"18\" /><Rectangle Tag=\"I3\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"14\" /><Rectangle Tag=\"I2\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"14\" /><Rectangle Tag=\"PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"37\" Canvas.Top=\"10\" /><Rectangle Tag=\"MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"29\" Canvas.Top=\"10\" /></Canvas><Canvas Tag=\"Left\"><Rectangle Tag=\"O1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"26\" /><Rectangle Tag=\"O0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"26\" /><Rectangle Tag=\"I9\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"22\" /><Rectangle Tag=\"I8\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"22\" /><Rectangle Tag=\"I5\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"18\" /><Rectangle Tag=\"I4\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"18\" /><Rectangle Tag=\"I1\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"15\" Canvas.Top=\"14\" /><Rectangle Tag=\"I0\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"7\" Canvas.Top=\"14\" /></Canvas></Canvas></Canvas>";

        public TestDataContext()
        {
            var list = new List<Module>
            {
                //new Module(xaml1)  { OrderCode = "CPX-AP-I-EP-M12", Name="CPX-AP-I-EP-M12" },
                //new Module(xaml2) { OrderCode = "CPX-AP-I-M12" , Name = "CPX-AP-I-M12"},
                //new Module(xaml3)  { OrderCode = "CPX-AP-I-M8_Compact" , Name="CPX-AP-I-M8_Compact"},
                //new Module(xaml4) { OrderCode = "CPX-AP-I-M12" , Name = "CPX-AP-I-M12"},

                new Module(xaml6)
                {
                    OrderCode = string.Format("CPX-AP-A-12DI4DO-M12-5P {0}", _counter), Name = "CPX-AP-A-12DI4DO-M12-5P"
                },
                new Module(xaml5) { OrderCode = "VABA-S6-1-X5", Name = "VABA-S6-1-X5" },

                new Module(xaml7) { OrderCode = "CPX-AP-A-16DI-D-M12-5P", Name = "CPX-AP-A-16DI-D-M12-5P" },
                new Module(xaml8) { OrderCode = "CPX-AP-A-4IOL-M12", Name = "CPX-AP-A-4IOL-M12" },
                new Module(xaml9) { OrderCode = "CPX-AP-A-12DI4DO-M8-4P", Name = "CPX-AP-A-12DI4DO-M8-4P" }
            };


            var items = new List<CatalogModuleProductViewModel>
            {
                new CatalogModuleProductViewModel(xaml1) { OrderCode = "CPX-AP-I-EP-M12" },
                new CatalogModuleProductViewModel(xaml2) { OrderCode = "CPX-AP-I-M12" },
                new CatalogModuleProductViewModel(xaml3) { OrderCode = "CPX-AP-I-M8_Compact" },
                new CatalogModuleProductViewModel(xaml4) { OrderCode = "CPX-AP-I-M12" },
                new CatalogModuleProductViewModel(xaml6) { OrderCode = "CPX-AP-A-12DI4DO-M12-5P" }
            };

            Devices = new ObservableCollection<Module>(list);
            GenerateRandomAPAddresses();

            Devices.CollectionChanged += Devices_CollectionChanged;

            CatalogItems = new ObservableCollection<CatalogModuleProductViewModel>(items);
            SignalDevice = new BaseCommand(this, p =>
            {
                if (SelectedDevice == null)
                    return;
                SelectedDevice.SignalReplaceDrop = !SelectedDevice.SignalReplaceDrop;
            });
            AddDevice = new BaseCommand(this, p =>
            {
                if (SelectedCatalogueItem == null)
                    return;

                _counter++;

                Devices.Add(new Module(SelectedCatalogueItem.XamlMarkup)
                {
                    OrderCode = string.Format("{0} {1}", SelectedCatalogueItem.OrderCode, _counter),
                    Name = SelectedCatalogueItem.OrderCode
                });
            });
            PasteDevice = new BaseCommand(this, p => { });
            DoubleClickDevice = new BaseCommand(this, p => { });
            ModuleNameEditEndingCommand = new BaseCommand();
            GenerateAddressesCommand = new BaseCommand(this, p => { GenerateRandomAPAddresses(); });

            JogLeftCommand = new BaseCommand(this, x =>
            {
                Console.WriteLine("JogLeftCommand");

                foreach (var l in Trace.Listeners)
                {
                    if (l is DefaultTraceListener)
                    {
                        ((DefaultTraceListener)l).AssertUiEnabled = false;
                    }
                }

                Debug.Fail("fail");

            });
            JogStopCommand = new BaseCommand(this, x => Console.WriteLine("JogStopCommand"));

            ModulePlaceholderReadGuid();
            //FillPlaceholder(list[4], list[5]);
        }

        public ObservableCollection<CatalogModuleProductViewModel> CatalogItems { get; set; }
        public CatalogModuleProductViewModel SelectedCatalogueItem { get; set; }
        public DragHandler DragHandler { get; set; }
        public ICommand AddDevice { get; set; }
        public ICommand SignalDevice { get; set; }

        public ICommand GenerateAddressesCommand { get; set; }

        public ICommand ModuleNameEditEndingCommand { get; set; }
        public ICommand JogLeftCommand { get; }
        public ICommand JogStopCommand { get; }

        public static void FillPlaceholder(Module placeholder, Module slotIn)
        {
            if (placeholder?.Placeholder == null)
                return;

            if (slotIn == null)
            {
                AddWithInVisualTree(placeholder.Placeholder, null);
                placeholder.SlotIn = null;
                return;
            }

            // remove old slot-in
            if (placeholder.SlotIn != null)
            {
                var oldSlotIn = placeholder.SlotIn;
                oldSlotIn.DeviceImage = Module.CreateImageObject(oldSlotIn.XamlMarkup, DeviceImageType.XamlMarkup);
            }

            // set new slot-in            
            slotIn.DeviceImage = Module.CreateImageObject(slotIn.XamlMarkup, DeviceImageType.XamlMarkup);

            var newElement = slotIn.DeviceImage as FrameworkElement;

            AddWithInVisualTree(placeholder.Placeholder, newElement);


            try
            {
                var translateTransform = new TranslateTransform(
                    SuiteProps.GetTranslateTransformX(placeholder.Placeholder),
                    SuiteProps.GetTranslateTransformY(placeholder.Placeholder));
                newElement.RenderTransform = translateTransform;
            }
            catch (Exception)
            {
                Debug.Fail($"SuiteProps.TranslateTransform missing for {placeholder.Placeholder.Name}");
            }

            placeholder.SlotIn = slotIn;
            slotIn.IsSlotIn = true;
        }

        public static void AddWithInVisualTree(FrameworkElement referencedElement, FrameworkElement newControl)
        {
            var frameworkElement = referencedElement.Parent as FrameworkElement;

            var panel = frameworkElement as Panel;
            if (panel == null)
            {
                var decorator = frameworkElement as Decorator;
                if (decorator == null)
                {
                    var contentControl = frameworkElement as ContentControl;
                    if (contentControl == null) throw new NotImplementedException("Unknown UI-Type");

                    contentControl.Content = newControl;
                }
                else
                {
                    decorator.Child = newControl;
                }

                return;
            }

            RemoveOldSlotInElement(panel);

            if (newControl == null) return;

            for (var i = 0; i < panel.Children.Count; i++)
                if (panel.Children[i] == referencedElement)
                {
                    //panel.Children.RemoveAt(i);
                    newControl.Tag = "SlotInModule";
                    panel.Children.Insert(i, newControl);
                    break;
                }
        }

        private static void RemoveOldSlotInElement(Panel panel)
        {
            var children = new List<FrameworkElement>();
            foreach (var c in panel.Children)
                children.Add(c as FrameworkElement);
            var slots = children.Where(x => x.Tag as string == "SlotInModule");
            foreach (var s in slots)
                panel.Children.Remove(s);
        }

        private void ModulePlaceholderReadGuid()
        {
            var placeholder = new Module(xaml5);

            var element = FindChildByTag(placeholder.DeviceImage, "ModulePlaceHolder");
            if (element != null)
            {
                var insertedValue = SuiteProps.GetModulePlaceHolder(element as FrameworkElement);
            }
        }

        public static DependencyObject FindChildByTag(DependencyObject parent, string tagName)
        {
            // confirm parent and name are valid.
            if (parent == null || string.IsNullOrEmpty(tagName)) return null;

            if (parent is FrameworkElement && (parent as FrameworkElement).Tag as string == tagName) return parent;

            DependencyObject result = null;

            if (parent is FrameworkElement) (parent as FrameworkElement).ApplyTemplate();

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                result = FindChildByTag(child, tagName);
                if (result != null) break;
            }

            return result;
        }

        private void Devices_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("e.Action: {0}", e.Action);
            Console.WriteLine("e.OldStartingIndex: {0}, e.NewStartingIndex: {1}", e.OldStartingIndex,
                e.NewStartingIndex);
        }

        public void Add()
        {
            counter++;
            Devices.Add(new Module(xaml1) { OrderCode = "CPX-AP-I-EP-M12 " + counter });
        }

        public void GenerateRandomAPAddresses()
        {
            var r = new Random();
            foreach (var m in Devices) m.Address = r.Next();
        }

        #region Terminal dependency properties

        public ICommand DoubleClickDevice { get; set; }
        public ICommand PasteDevice { get; set; }
        public ObservableCollection<Module> Devices { get; set; }
        public Module SelectedDevice { get; set; }

        private RelayCommand exceptionCommand;

        public ICommand ThrowExceptionCommand
        {
            get
            {
                if (exceptionCommand == null)
                {
                    exceptionCommand = new RelayCommand(PerformThrowException);
                }

                return exceptionCommand;
            }
        }

        private void PerformThrowException(object commandParameter)
        {

            Exception exception = null;

            //Task.Run(() => 
            //{
            //    try 
            //    {
            //        Task.Delay(5000).Wait();

            //        throw new Exception("hallo exception");
            //    }catch (Exception ex) { exception = ex; }


            //}).ContinueWith((t) => 
            //{
            //    if (exception != null) { throw exception; }
            //}, TaskContinuationOptions.OnlyOnFaulted);

            //await Task.Run(() => {

            //    Task.Delay(5000).Wait();
            //    MessageBox.Show("exception.ToString()");
            //    throw new Exception("hallo exception"); 
            //});


            
            Task.Run(() =>
                {
                    try
                    {
                        Task.Delay(5000).Wait();
                        throw new InvalidOperationException();
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }

                }).GetAwaiter().OnCompleted(() =>
                {
                    if (exception != null)
                    {
                        MessageBox.Show(exception.ToString());
                        throw exception;
                    }


                });


        }
        #endregion
    }


    public class BaseCommand : ICommand
    {
        private readonly Action<object> execute;

        private TestDataContext vm;

        public BaseCommand(TestDataContext vm, Action<object> execute)
        {
            this.vm = vm;
            this.execute = execute;
        }

        public BaseCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
//            execute?.Invoke(parameter);

            // Start the delay.
            var delayTask = DelayAsync();
            
            
            // Wait for the delay to complete.
            delayTask.Wait();

        }
        private static async Task DelayAsync()
        {
            //TaskCompletionSource<bool> tsc = new TaskCompletionSource<bool>();
            //await tsc.Task.ConfigureAwait(false);

            await Task.Delay(1000).ConfigureAwait(false);
//            await Task.Delay(1000);//.ConfigureAwait(false);
        }

        static Task InnerTask()
        {
            var tcs =  new TaskCompletionSource<bool>();

            Task.Run(()=> tcs.SetResult(true))
            ;

            return tcs.Task;
        }

        public event EventHandler CanExecuteChanged;
    }
}
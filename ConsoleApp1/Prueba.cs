using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Prueba : IDisposable
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<String, Object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        string[,] data;



        public Prueba()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<String, Object>();
        }

        public void Dispose()
        {
            driver.Quit();
        }
        public string waitForWindow(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }


        public void Xtft()
        {
            List<string[,]> listadoDeData = new List<string[,]>();
         

            //EsMovil 
            data = crearData("iphone 6");
            
            driver.Navigate().GoToUrl("https://esmovil.es/es/");     
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 1391);             
            driver.FindElement(By.LinkText("Iniciar sesión")).Click();           
            driver.FindElement(By.Id("email")).SendKeys("******");            
            driver.FindElement(By.Id("passwd")).SendKeys("******");            
            driver.FindElement(By.Name("customerRegisterEmail")).SendKeys("******");            
            driver.FindElement(By.Name("customerRegisterPass")).SendKeys("*******");
            driver.FindElement(By.Id("SubmitLogin")).Click();

            //URL PANTALLAS EsMovil
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/3154-iphone-6-pantalla-lcd-tactil-negro-compatible-0000124600063.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12895-iphone-6-pantalla-lcd-tactil-negro-compatible-hq-9900000128951.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7714-iphone-6-pantalla-lcd-tactil-negro-reacondicionado-9900000077143.html", data, 4, 1);

            //***************************************************************************************************************************************************************           

            //Repuestos Fuentes 
            driver.Navigate().GoToUrl("https://www.repuestosfuentes.es/autenticacion?back=my-account");
            driver.FindElement(By.XPath("//*[@id=\"soycontrolcookies\"]/div[1]/div[2]/button[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name=\'email\'])[2]")).SendKeys("******");
            driver.FindElement(By.Name("password")).SendKeys("******");
            driver.FindElement(By.XPath("//*[@id=\"submit-login\"]")).Click();

            // URL PANTALLAS RepuestosFuentes
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-6-blanco-20696.html", data, 1,2);


            //***************************************************************************************************************************************************************

            //Phone Component 
            // LOGIN PhoneComponentes
            driver.Navigate().GoToUrl("https://phonecomponente.com/index.php?id_cms=10&controller=cms");
            driver.FindElement(By.Name("email")).SendKeys("******");
            driver.FindElement(By.Name("password")).SendKeys("******");
            driver.FindElement(By.Id("submit-login")).Click();

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/7456-3344-pantalla-completa-para-iphone-6-aaa-con-aumentador-de-brillo.html#/1-color-negro", data, 1,3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/3959-1294-pantalla-completa-para-iphone-6-remanufacturada-con-cristal-original.html#/1-color-negro", data, 4,3);

            //***************************************************************************************************************************************************************

            //RPhone 
            // LOGIN RPHone
            driver.Navigate().GoToUrl("https://rphoneb2b.com/iniciar-sesion?back=my-account");
            driver.FindElement(By.Name("email")).SendKeys("INFORMATICO.ASC@GMAIL.COM");
            driver.FindElement(By.Name("password")).SendKeys("17391739");
            driver.FindElement(By.Id("submit-login")).Click();

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16634-pantalla-para-iphone-6-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1,4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16636-pantalla-para-iphone-6-original-remanufacturada-blanca.html", data, 4,4);

            //***************************************************************************************************************************************************************
            listadoDeData.Add(data);



            data = crearData("Iphone 6 Plus");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12898-iphone-6-plus-pantalla-lcd-tactil-blanco-compatible-hq-9900000128982.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12900-iphone-6-plus-pantalla-lcd-tactil-negro-compatible-hq-9900000129002.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7716-iphone-6-plus-pantalla-lcd-tactil-negro-reacondicionado-9900000077167.html", data, 4, 1);


            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-6-plus-blanca-22492.html", data,1,2);


            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/923-444-pantalla-completa-para-iphone-6-plus-acon-aumentador-de-brillo.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12091-10633-pantalla-completa-para-iphone-6-plus-aaacon-aumentador-de-brillo.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13728-12208-lcd-display-screen-touch-for-iphone-6-plus-complete-view-good-image-quality-aaaa.html#/1-color-negro", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/3960-1296-pantalla-completa-para-iphone-6-plus-remanufacturada-con-cristal-original.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16599-pantalla-para-iphone-6-plus-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16601-pantalla-para-iphone-6-plus-re-blanca.html", data, 4, 4);

            listadoDeData.Add(data);


            data = crearData("Iphone 6s");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/620-iphone-6s-pantalla-lcd-tactil-negro-compatible-9900000006204.html",  data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12902-iphone-6s-pantalla-lcd-tactil-blanco-compatible-hq-9900000129026.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7718-iphone-6s-pantalla-lcd-tactil-negro-reacondicionado-9900000077181.html", data, 4, 1);


            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-6s-blanca-25363.html", data, 1, 2);


            //rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/1529-801-pantalla-completa-para-iphone-6s-acon-aumentador-de-brillo.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12089-10629-pantalla-completa-para-iphone-6s-aaacon-aumentador-de-brillo.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/3975-1325-pantalla-completa-para-iphone-6s-remanufacturada-con-cristal-original.html#/1-color-negro", data, 4, 3);

        
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16561-pantalla-para-iphone-6s-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data,1,4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16563-pantalla-para-iphone-6s-original-remanufacturada-blanca.html", data,4,4);

            listadoDeData.Add(data);

            data = crearData("Iphone 6s Plus");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/621-iphone-6s-plus-pantalla-lcd-tactil-negro-compatible-9900000006211.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12908-iphone-6s-plus-pantalla-lcd-tactil-negro-compatible-hq-9900000129088.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7721-iphone-6s-plus-pantalla-lcd-tactil-blanco-reacondicionado-9900000077211.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-6s-plus-blanca--31019.html", data, 1, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/1530-803-pantalla-completa-para-iphone-6s-plus-acon-aumentador-de-brillo.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13391-11972-pantalla-completa-para-iphone-6s-plus-aaacon-aumentador-de-brillo.html#/1-color-negro",data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13856-12311-pantalla-completa-para-iphone-6s-plus-vision-completa-alta-gama-de-imagen-aaaa.html#/1-color-negro",data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/3976-1327-pantalla-completa-para-iphone-6s-plus-remanufacturada.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16522-pantalla-para-iphone-6s-plus-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16524-pantalla-para-iphone-6s-plus-re-blanca.html", data, 4, 4);

            listadoDeData.Add(data);


            data = crearData("Iphone 7");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/1474-iphone-7-pantalla-lcd-tactil-blanco-compatible-9900000014742.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12930-iphone-7-pantalla-lcd-tactil-negro-compatible-hq-9900000129309.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7722-iphone-7-pantalla-lcd-tactil-negro-reacondicionado-9900000077228.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-7-blanca-35431.html", data,1,2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/4854-1430-pantalla-completa-para-iphone-7-acon-aumentador-de-brillo.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12090-10631-pantalla-completa-para-iphone-7-aaacon-aumentador-de-brillo.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13175-11783-pantalla-completa-para-iphone-7-vision-completa-alta-gama-de-imagen-aaaa.html#/1-color-negro", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12177-10717-pantalla-completa-para-iphone-7-original-reparada-ch.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16486-pantalla-para-iphone-7-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16488-pantalla-para-iphone-7-original-remanufacturada-blanca.html", data, 4, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 7 Plus");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/3259-iphone-7-plus-pantalla-lcd-tactil-negro-compatible-9900000032593.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12921-iphone-7-plus-pantalla-lcd-tactil-negro-compatible-hq-9900000129217.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/6347-iphone-7-plus-pantalla-lcd-tactil-blanco-reacondicionado-9900000063474.html", data, 4, 1);


            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-7-plus-blanca-35428.html", data, 1, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/5128-1435-pantalla-completa-para-iphone-7-plus-acon-aumentador-de-brillo.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12093-10637-pantalla-completa-para-iphone-7-plus-aaacon-aumentador-de-brillo.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13729-12210-pantalla-completa-para-iphone-7-plus-vision-completa-alta-gama-de-imagen-aaaa.html#/1-color-negro", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/5786-1677-pantalla-completa-para-iphone-7-plus-original-remanufacturada.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16443-pantalla-para-iphone-7-plus-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/17737-pantalla-para-iphone-7-plus-original-remanufacturada-blanca.html", data, 4, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 8SE");


            rellenarNombrePrecioEsMovil("https://esmovil.es/es/6388-iphone-8-se-2020-pantalla-lcd-tactil-negro-compatible-9900000063887.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12925-iphone-8-se-2020-pantalla-lcd-tactil-negro-compatible-hq-9900000129255.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/8148-iphone-8-se-2020-pantalla-lcd-tactil-negro-reacondicionado-9900000081485.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-8-se-2020-se-2022-blanca-47558.html", data, 1, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13544-12086-pantalla-completa-para-iphone-8-acon-aumentador-de-brilloiphone-se-2020.html#/1-color-negro", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/7766-2103-pantalla-completa-para-iphone-8-aaacon-aumentador-de-brilloiphone-se-2020.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13857-12313-pantalla-completa-para-iphone-8-vision-completa-alta-gama-de-imagen-aaaaiphone-se-2020.html#/1-color-negro", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/8158-2332-pantalla-completa-para-iphone-8-original-reparadaiphone-se-2020.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16411-pantalla-para-iphone-8-se-2020-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16413-pantalla-para-iphone-8-se-2020-original-remanufacturada-blanca.html", data, 4, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 8 Plus");


            rellenarNombrePrecioEsMovil("https://esmovil.es/es/6391-iphone-8-plus-pantalla-lcd-tactil-blanco-compatible-9900000063917.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/12927-iphone-8-plus-pantalla-lcd-tactil-blanco-compatible-hq-9900000129279.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/8151-iphone-8-plus-pantalla-lcd-tactil-blanco-reacondicionado-9900000081515.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-display-tactil-para-iphone-8-plus-blanca-48020.html", data, 1, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13545-12089-pantalla-completa-para-iphone-8-plus-acon-aumentador-de-brillo.html#/2-color-blanco", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/7767-2105-pantalla-completa-para-iphone-8-plus-aaacon-aumentador-de-brillo.html#/1-color-negro", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13730-12212-pantalla-completa-para-iphone-8-plus-vision-completa-alta-gama-de-imagen-aaaa.html#/1-color-negro", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/8196-2362-pantalla-completa-para-iphone-8-plus-original-reparada.html#/1-color-negro", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16375-pantalla-para-iphone-8-plus-aaaa-con-aumentardor-de-brillo-vision-completa-blanca.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16379-pantalla-para-iphone-8-plus-original-remanufacturada-blanca.html", data, 4, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone X");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/7864-iphone-x-pantalla-lcd-tactil-negro-a1901-compatible-tft-incell-9900000078645.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/24696-iphone-x-pantalla-lcd-tactil-negro-a1901-compatible-hq-hard-oled-9900000246969.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/11529-iphone-x-pantalla-lcd-tactil-negro-a1901-compatible-hq-soft-oled-9900000115296.html", data, 3, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/16342-iphone-x-pantalla-lcd-tactil-negro-reacondicionado-9900000163426.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-x-negra-calidad-incell-68944.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-x-negra-calidad-oled-55044.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13747-pantalla-completa-para-iphone-x-tft-cof-incell-premiumfunciona-con-3d-touch.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/11954-pantalla-completa-para-iphone-x-amoled-durofunciona-con-3d-touch.html", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/8588-pantalla-completa-para-iphone-x-amoled-flexible-funciona-con-3d-touch.html", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/11479-pantalla-completa-para-iphone-x-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16353-pantalla-para-iphone-x-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/17698-pantalla-para-iphone-x-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19426-pantalla-para-iphone-x-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone XS");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/14557-iphone-xs-pantalla-lcd-tactil-negro-a2097-compatible-tft-incell-9900000145576.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/25902-iphone-xs-pantalla-lcd-tactil-negro-a2097-compatible-hq-hard-oled-9900000259020.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/10967-iphone-xs-pantalla-lcd-tactil-negro-a2097-compatible-hq-soft-oled-9900000109677.html", data, 3, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/17935-iphone-xs-pantalla-lcd-tactil-negro-reacondicionado-9900000179359.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-y-tactil-para-iphone-xs-negra-calidad-incell-69237.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-oled-y-tactil-para-iphone-xs-negra-58547.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13748-pantalla-completa-para-iphone-xs-tft-cof-incell-premiumfunciona-con-3d-touch.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/11955-pantalla-completa-para-iphone-xs-amoled-durofunciona-con-3d-touch.html", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/11550-pantalla-completa-para-iphone-xs-amoled-flexiblefunciona-con-3d-touch.html", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12355-pantalla-completa-para-iphone-xs-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16875-pantalla-para-iphone-xs-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/18353-pantalla-para-iphone-xs-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19399-pantalla-para-iphone-xs-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);


            data = crearData("Iphone XS Max");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/16357-iphone-xs-max-pantalla-lcd-tactil-negro-a2101-compatible-tft-incell-9900000163570.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/10968-iphone-xs-max-pantalla-lcd-tactil-negro-a2101-compatible-hq-hard-oled-9900000109684.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/26023-iphone-xs-max-pantalla-lcd-tactil-negro-a2101-compatible-hq-soft-oled-9900000260231.html", data, 3, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/22583-iphone-xs-max-a2101-pantalla-lcd-tactil-negro-reacondicionado-9900000225834.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-y-tactil-para-iphone-xs-max-negra-calidad-incell-68567.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-oled-y-tactil-para-iphone-xs-max-negra-58548.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13731-pantalla-completa-para-iphone-xs-max-tft-cof-incell-premiumfunciona-con-3d-touch.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/18345-pantalla-completa-para-iphone-xs-max-amoled-durofunciona-con-3d-touch.html", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/18346-pantalla-completa-para-iphone-xs-max-amoled-flexiblefunciona-con-3d-touch.html", data, 3, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/12254-pantalla-completa-para-iphone-xs-max-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/17635-pantalla-para-iphone-xs-max-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16272-pantalla-para-iphone-xs-max-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19400-pantalla-para-iphone-xs-max-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone XR");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/15814-iphone-xr-pantalla-lcd-tactil-negro-a2105-compatible-tft-incell-9900000158149.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/10966-iphone-xr-pantalla-lcd-tactil-negro-a2105-compatible-hq-tft-incell-9900000109660.html", data, 2, 1);            
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/17934-iphone-xr-pantalla-lcd-tactil-negro-reacondicionado-9900000179342.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-iphone-xr-negra-58544.html", data, 1, 2);            

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13749-pantalla-completa-para-iphone-xr-tft-cof-incell-premiumfunciona-con-3d-touch.html", data, 1, 3);            
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/11650-pantalla-completa-para-iphone-xr-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16324-pantalla-para-iphone-xr-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16272-pantalla-para-iphone-xs-max-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/12726-pantalla-para-iphone-xr-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 11");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/16358-iphone-11-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000163587.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/18518-iphone-11-pantalla-lcd-tactil-negro-compatible-hq-tft-incell-9900000185183.html", data, 2, 1);            
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/21881-iphone-11-pantalla-lcd-tactil-negro-reacondicionado-9900000218812.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-y-tactil-para-iphone-11-negro--65723.html", data, 1, 2);            

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13009-pantalla-completa-para-iphone-11-tft-cof-incell-premiumfunciona-con-3d-touch.html", data, 1, 3);            
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13158-pantalla-completa-para-iphone-11-original-reparadacon-chapa-metalica.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16244-pantalla-para-iphone-11-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19432-pantalla-para-iphone-11-original.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19401-pantalla-para-iphone-11-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 11 PRO");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/17437-iphone-11-pro-pantalla-lcd-tactil-negro-compatible-hard-oled-9900000174378.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/18517-iphone-11-pro-pantalla-lcd-tactil-negro-compatible-hq-soft-oled-9900000185176.html", data, 2, 1);            
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/24003-iphone-11-pro-pantalla-lcd-tactil-negro-reacondicionado-9900000240035.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-completa-con-marco-para-iphone-11-pro-negra-calidad-incell-71352.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-oled-y-tactil-para-iphone-11-pro-68083.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15028-pantalla-completa-para-iphone-11-pro-tft-cof-incell-premium.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15281-pantalla-completa-para-iphone-11-pro-amoled-duro.html", data, 2, 3);            
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13010-pantalla-completa-para-iphone-11-pro-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16215-pantalla-para-iphone-11-pro-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19318-pantalla-para-iphone-11-pro-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19402-pantalla-para-iphone-11-pro-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 11 PRO Max");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/17438-iphone-11-pro-max-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000174385.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/26635-iphone-11-pro-max-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000266356.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/18516-iphone-11-pro-max-pantalla-lcd-tactil-negro-compatible-hq-soft-oled-9900000185169.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/24003-iphone-11-pro-pantalla-lcd-tactil-negro-reacondicionado-9900000240035.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-lcd-y-tactil-para-iphone-11-pro-max-calidad-incell-70465.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-oled-y-tactil-para-iphone-11-pro-max-68082.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15029-pantalla-completa-para-iphone-11-pro-max-tft-cof-incell-premium.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15282-pantalla-completa-para-iphone-11-pro-max-amoled-buena-calidad.html", data, 2, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/13011-pantalla-completa-para-iphone-11-pro-max-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/17772-pantalla-para-iphone-11-pro-max-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/16189-pantalla-para-iphone-11-pro-max-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19403-pantalla-para-iphone-11-pro-max-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 12 Mini");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/21834-iphone-12-mini-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000218348.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/29964-iphone-12-mini-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000299644.html", data, 2, 1);            
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31899-iphone-12-mini-pantalla-lcd-tactil-negro-reacondicionado-9900000318994.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-completa-para-iphone-12-mini-a2399-incell-alta-calidad-76447.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-12-mini-negro-oled-73457.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/18949-pantalla-completa-para-iphone-12-mini-tft-cof-incell-premium.html", data, 1, 3);            
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/18920-pantalla-completa-para-iphone-12-mini-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/18315-pantalla-para-iphone-12-mini-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/12698-pantalla-para-iphone-12-mini-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/13089-pantalla-para-iphone-12-mini-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 12 - 12 PRO");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/21833-iphone-12-12-pro-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000218331.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/26636-iphone-12-12-pro-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000266363.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31898-iphone-12-12-pro-pantalla-lcd-tactil-negro-reacondicionado-9900000318987.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-12-iphone-12-pro-incell-75698.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-12-iphone-12-pro-oled-73459.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15529-pantalla-completa-para-iphone-12-tft-cof-incell-premiumiphone-12-pro.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15972-pantalla-completa-para-iphone-12-original-reparadaiphone-12-pro.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/18316-pantalla-para-iphone-12-12-pro-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/15325-pantalla-para-iphone-12-12-pro-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19404-pantalla-para-iphone-12-12-pro-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 12 Pro Max");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/24327-iphone-12-pro-max-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000243272.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/29981-iphone-12-pro-max-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000299811.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31900-iphone-12-pro-max-pantalla-lcd-tactil-negro-reacondicionado-9900000319007.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-12-pro-max-a2342-a2410-a2411-a2412-negro-incell-75864.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-12-pro-max-a2342-a2410-a2411-a2412-negro-oled-73458.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15530-pantalla-completa-para-iphone-12-pro-max-tft-cof-incell-premium.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/15973-pantalla-completa-para-iphone-12-pro-max-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/18317-pantalla-para-iphone-12-pro-max-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/17287-pantalla-para-iphone-12-pro-max-oled.html", data, 2, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/13086-pantalla-para-iphone-12-pro-max-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 13 Mini");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/34610-iphone-13-mini-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000346102.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/34611-iphone-13-mini-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000346119.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31903-iphone-13-mini-pantalla-lcd-tactil-negro-reacondicionado-9900000319038.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-completa-con-marco-iphone-13-mini-negra-calidad-incell-82081.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/pantalla-completa-con-marco-iphone-13-mini-negra-calidad-oled-82251.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20984-pantalla-completa-para-iphone-13-mini-tft-cof-incell-premium.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20821-pantalla-completa-para-iphone-13-mini-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19207-pantalla-para-iphone-13-mini-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/12892-pantalla-para-iphone-13-mini-oled.html", data, 2, 4);
            

            listadoDeData.Add(data);

            data = crearData("Iphone 13");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/34608-iphone-13-pantalla-lcd-tactil-negro-compatible-tft-incell-9900000346089.html", data, 1, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/34609-iphone-13-pantalla-lcd-tactil-negro-compatible-hq-hard-oled-9900000346096.html", data, 2, 1);
            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31902-iphone-13-pantalla-lcd-tactil-negro-reacondicionado-9900000319021.html", data, 4, 1);

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-13-negra-calidad-incell-81633.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-13-negra-calidad-oled-82634.html", data, 2, 2);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/19888-pantalla-completa-para-iphone-13-tft-cof-incell-premium.html", data, 1, 3);
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20137-pantalla-completa-para-iphone-13-original-reparada.html", data, 4, 3);

            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/19208-pantalla-para-iphone-13-incell.html", data, 1, 4);
            rellenarNombrePrecioRPhone("https://rphoneb2b.com/modelos-smartphone/13092-pantalla-para-iphone-13-original-remanufacturada-oem-original.html", data, 2, 4);


            listadoDeData.Add(data);

            data = crearData("Iphone 13 Pro");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31905-iphone-13-pro-pantalla-lcd-tactil-negro-reacondicionado-9900000319052.html", data, 4, 1);           
            
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20070-pantalla-completa-para-iphone-13-pro-original-reparada.html", data, 4, 3);
                       
            listadoDeData.Add(data);

            data = crearData("Iphone 13 Pro Max");

            rellenarNombrePrecioEsMovil("https://esmovil.es/es/31904-iphone-13-pro-max-pantalla-lcd-tactil-negro-reacondicionado-9900000319045.html", data, 4, 1);

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20124-pantalla-completa-para-iphone-13-pro-max-original-reparada.html", data, 4, 3);

            listadoDeData.Add(data);

            data = crearData("Iphone 14");         

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-14-negra-calidad-incell-85696.html", data, 1, 2);
            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-14-negra-calidad-oled-premium-85466.html", data, 2, 2);
           
            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20788-pantalla-completa-para-iphone-14-original-reparada.html", data, 4, 3);         

            listadoDeData.Add(data);

            data = crearData("Iphone 14 Plus");

            rellenarNombrePrecioRepuestosFuente("https://www.repuestosfuentes.es/modulo-completo-de-pantalla-para-iphone-14-plus-negra-calidad-incell--85500.html", data, 1, 2);            

            rellenarNombrePrecioPhoneComonent("https://phonecomponente.com/es/repuestos-m%C3%B3viles/20794-pantalla-completa-para-iphone-14-plus-original-reparada.html", data, 4, 3);

            listadoDeData.Add(data);

            CrearFichero(listadoDeData);
        }

        private string[,] RellenarSaltoLinea()
        {
            return new string[,]
            {
                { "", "", "","",""},               
            };
        }

        private string[,] crearData(string nombre)
        {
            return new string[,]
            {
                { nombre, "EsMovil", "RepuestosFuente","PhoneComponent","RPhone"},
                { "Compatible", "", "","" ,""},
                { "Compatible HQ", "", "","" ,""},
                { "Compatible HQ Plus", "", "","" ,""},
                { "Original", "", "","" , ""}
            };
        }

        private void rellenarNombrePrecioEsMovil(string url,string[,] data,int posX,int posY)
        {
            driver.Navigate().GoToUrl(url);            
            var vPrecio = driver.FindElement(By.XPath("//*[@id=\"center_column\"]/div[1]/div[2]/div[1]/div[1]/div[1]/p")).Text;           
            data.SetValue(vPrecio.Replace(" € IVA incluido", "").ToString(), posX, posY);
        }

        private void rellenarNombrePrecioRepuestosFuente(string url, string[,] data, int posX, int posY)
        {
            driver.Navigate().GoToUrl(url);
            var vPrecio = driver.FindElement(By.XPath("//*[@id=\"main\"]/div[2]/div[3]/div[1]/div[1]/div/span")).Text;
            data.SetValue(vPrecio.Replace(" €", "").ToString(), posX, posY);

        }

        private void rellenarNombrePrecioPhoneComonent(string url, string[,] data, int posX, int posY)
        {
            driver.Navigate().GoToUrl(url);
            var vPrecio = driver.FindElement(By.XPath("//*[@id=\"main\"]/div[1]/div[2]/div[1]/div[1]/div/span")).Text;
            data.SetValue(vPrecio.Replace(" €", "").ToString(), posX, posY);          
        }

        private void rellenarNombrePrecioRPhone(string url, string[,] data, int posX, int posY)
        {
            driver.Navigate().GoToUrl(url);
            var vPrecio = driver.FindElement(By.XPath("//*[@id=\"add-to-cart-or-refresh\"]/div[2]/div[1]/div/span")).Text;
            data.SetValue(vPrecio.Replace(" €", "").ToString(), posX, posY);
        }

        private void CrearFichero(List<string[,]> listaData)
        {
           

            string filePath = "datos.csv";

            using (var writer = new StreamWriter(filePath))
            {
                foreach(var data in listaData)
                {
                    int rowCount = data.GetLength(0);
                    int columnCount = data.GetLength(1);

                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            writer.Write(data[i, j]);

                            if (j < columnCount - 1)
                                writer.Write(";");
                        }
                        writer.WriteLine();
                    }
                    writer.Write( Environment.NewLine);
                }                
            }

            Console.WriteLine("Archivo CSV creado correctamente.");
        }
    }
}

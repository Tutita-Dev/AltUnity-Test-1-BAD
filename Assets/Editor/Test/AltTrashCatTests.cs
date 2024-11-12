using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using NUnit.Framework.Internal;


public class AltTrashCatTests

{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void TestStartButtonLoadMainScene()
    {
        altDriver.LoadScene("Start");
        altDriver.FindObject(By.NAME, "StartButton").Click();
        altDriver.WaitForCurrentSceneToBe("Main");
    }
    // Test para verificar que el Canvas "Game" se activa despu�s de hacer clic en el bot�n Start
    [Test]
    public void TestStartButtonActivatesGameCanvas()
    {
        // Cargar la escena principal que contiene el Canvas "Loadout"
        altDriver.LoadScene("Main");  // Aqu� asumo que la escena que contiene el canvas "Loadout" se llama "Main"

        // Asegurarse de que el Canvas Loadout est� activo
        altDriver.FindObject(By.NAME, "Loadout");  // Aseg�rate de que el Canvas tenga el nombre correcto     

        // Buscar el bot�n "Start" dentro del Canvas Loadout usando FindObject y hace click
        altDriver.FindObject(By.NAME, "StartButton").Click();

        // Verifica que el Canvas "Game" se ha activado despu�s de hacer clic en el bot�n Start
        altDriver.FindObject(By.NAME, "Game");

    }
}
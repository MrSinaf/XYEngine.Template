using XYEngine;
using XYEngine.Rendering;
using XYEngine.Resources;
using XYEngine.Template;
using XYEngine.UI;
using XYEngine.UI.Widgets;
using XYEngine.Utils;

// Permet de lancer le jeu en référençant le nom, ainsi que la première Scène à afficher :
XY.LaunchGame<FirstScene>("XYTemplate", () =>
{
	/* Il est possible d'effectuer une Action pendant le SplashScreen pour mettre correctement en place votre jeu. */
	
	// On charge la texture nécessaire :
	var panel = AssetManager.LoadAsset<Texture2D>("panel.png");
	
	// Certains assets peuvent avoir des configurations par défaut :
	Texture2D.defaultConfig = new Texture2DConfig(TextureWrap.Repeat, TextureMag.Nearest);

	// Vous pouvez directement configurer des prefabs pour l'UI, avant le lancement du jeu :
	var sharedMat = new Material(AssetManager.GetEmbeddedAsset<Shader>("shaders.ui.shadxy"), ("mainTex", panel), ("padding", new Region(new Vector2(3))), ("paddingScale", 5F));
	var sharedMesh = MeshFactory.CreateQuad(Vector2.one).Apply();
	UIPrefab.Add<Panel>(null, e =>
	{
		e.material = sharedMat;
		e.mesh = sharedMesh;
	});
	UIPrefab.Add<Button>(null, e =>
	{
		e.material = sharedMat;
		e.mesh = sharedMesh;
		e.size = new Vector2Int(200, 30);
		e.tint = new Color(40, 40, 50);

		e.label.pivotAndAnchors = new Vector2(0.5F);
		e.label.letterCase = Label.Case.Upper;
		e.label.tint = Color.white;

		UIEvent.Register(e, UIEvent.Type.MouseEnter, () => e.tint = new Color(30, 50, 40));
		UIEvent.Register(e, UIEvent.Type.MouseExit, () => e.tint = new Color(40, 40, 50));
	});
});
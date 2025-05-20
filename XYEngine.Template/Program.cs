using XYEngine;
using XYEngine.Resources;
using XYEngine.Template;
using XYEngine.UI;
using XYEngine.UI.Widgets;
using XYEngine.Utils;

XY.LaunchGame<FirstScene>("XYTemplate", async () =>
{
	/* Il est possible d'effectuer des Actions pendant le SplashScreen pour charger des ressources et mettre en place par exemple les prefabs. */
	
	// On charge la texture nécessaire :
	var panel = await AssetManager.LoadAssetAsync<Texture2D>("panel.png");
	var sharedMat = new MaterialUI().SetTexture(panel).SetPadding(new Region(new Vector2(3)), 5F);
	
	UIPrefab.Add<Panel>(null, e =>
	{
		e.material = sharedMat;
		e.mesh = Primitif.quad;
	});
	UIPrefab.Add<Button>(null, e =>
	{
		e.material = sharedMat;
		e.mesh = Primitif.quad;
		e.size = new Vector2Int(200, 30);
		e.tint = new Color(40, 40, 50);
		
		e.label.pivotAndAnchors = new Vector2(0.5F);
		e.label.letterCase = Label.Case.Upper;
		e.label.tint = Color.white;
		
		UIEvent.Register(e, UIEvent.Type.MouseEnter, () => e.tint = new Color(30, 50, 40));
		UIEvent.Register(e, UIEvent.Type.MouseExit, () => e.tint = new Color(40, 40, 50));
	});
});
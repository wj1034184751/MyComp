using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace YuanTu.Platform.Print
{
    public interface ILayer
    {
        string Uid { get; set; }

        string Pid { get; set; }

        LayerType LayerType { get; set; }

        DockStyle Dock { get; set; }

        PPoint Location { get; set; }

        PSize Size { get; set; }

        bool IsBody { get; set; }

        decimal Ratio { get; set; }

        PPadding Padding { get; set; }

        PPadding Border { get; set; }

        int Zindex { get; set; }

        string Text { get; set; }

        string Field { get; set; }

        string Format { get; set; }

        string Color { get; set; }

        PFont Font { get; set; }

        Textalign Textalign { get; set; }

        bool Wordwrap { get; set; }

        bool Autosize { get; set; }

        float LineHeight { get; set; }

        string Vif { get; set; }

        JToken Source { get; set; }

        PPoint AbspLocation { get; set; }

        bool PageSplit { get; set; }

        List<Layer> Layers { get; set; }

        void Paint(object sender, PPaintEventArgs e);
    }
}
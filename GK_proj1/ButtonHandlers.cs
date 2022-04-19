using System;
using System.Windows.Forms;
using GK_proj1.Relations;

namespace GK_proj1
{
    public partial class Form1 : Form
    {
        private void NewPolygonButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.CreateNewPolygon;
        }

        private void CreateNewCircle_Click(object sender, EventArgs e)
        {
            Mode = Modes.CreateNewCircle;
        }

        private void DivideEdgeButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.DivideEdge;
        }

        private void DeletePointButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.DeletePoint;
        }
        private void DragPolygonButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.PolygonDrag;
        }

        private void DeleteRelationButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.RemoveRelation;
        }

        private void GenereatePredefinedSceneButton_Click(object sender, EventArgs e)
        {
            GenerateInitialScene();
        }

        private void EqualLengthEdgesButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddBinaryRelation1;
            _NewRelation = new EqualLengthRelation();
        }

        private void FixedLengthButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddUnaryRelation;
            _NewRelation = new FixedLengthRelation();
        }

        private void FixedPointButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddUnaryRelation;
            _NewRelation = new FixedPointRelation();
        }

        private void PerpendicularEdgesButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddBinaryRelation1;
            _NewRelation = new PerpendicularRelation();
        }

        private void TangentButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddBinaryRelation1;
            _NewRelation = new TangentRelation();
        }

        private void FixedRadiusButton_Click(object sender, EventArgs e)
        {
            Mode = Modes.AddUnaryRelation;
            _NewRelation = new FixedRadiusRelation();
        }

        private void AutoTangnetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoTangent = !AutoTangent;
        }

    }
}

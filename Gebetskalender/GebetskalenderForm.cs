using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gebetskalender
{
    public partial class GebetskalenderForm : Form
    {
        double tanPhi = 0;
        double phi = 0;
        double distance = 0;
        double directionAngle = 0;

        const double equatorialLength = 40075.017;
        const double degInKM = equatorialLength / 360;
        
        public GebetskalenderForm()
        {
            InitializeComponent();
            calcSomething();
        }

        double radToDeg(double angleRad)
        {
            return (180 * angleRad / Math.PI);
        }

        double degToRad(double angleRad)
        {
            return (Math.PI * angleRad / 180);
        }

        double calcDegToMetric(int deg, int arcmin, int arcsec)
        {
            return deg+(arcmin/60)+(arcsec/3600);
        }

        void calcSomething()
        {
            double meccaLatCoord = calcDegToMetric((int)numericUpDownMeccaLatDegree.Value, (int)numericUpDownMeccaLatArcmin.Value, (int)numericUpDownMeccaLatArcsec.Value);
            double meccaLongCoord = calcDegToMetric((int)numericUpDownMeccaLongDegree.Value, (int)numericUpDownMeccaLongArcmin.Value, (int)numericUpDownMeccaLongArcsec.Value);
            double cityLatCoord = calcDegToMetric((int)numericUpDownCityLatDegree.Value, (int)numericUpDownCityLatArcmin.Value, (int)numericUpDownCityLatArcsec.Value);
            double cityLongCoord = calcDegToMetric((int)numericUpDownCityLongDegree.Value, (int)numericUpDownCityLongArcmin.Value, (int)numericUpDownCityLongArcsec.Value);

            tanPhi = (cityLatCoord - meccaLatCoord) / (cityLongCoord - meccaLongCoord);
            labelTanPhi.Text = "tan φ = " + tanPhi.ToString("N4");

            phi = radToDeg(Math.Atan2((cityLatCoord - meccaLatCoord),(cityLongCoord - meccaLongCoord)));
            labelPhi.Text = "φ = " + phi.ToString("N4");

            distance = Math.Sqrt(Math.Pow(cityLongCoord - meccaLongCoord, 2) + Math.Pow(cityLatCoord - meccaLatCoord, 2)) * degInKM;
            labelDistance.Text = "Distanz: " + distance.ToString("N4");

            directionAngle = (Math.PI / 2) - tanPhi;
            labelDirectionAngle.Text = "Richtungswinkel: " + directionAngle.ToString("N4");

        }


        private void btnCalc_Click(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLatDegree_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLatArcmin_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLatArcsec_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLongDegree_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLongArcmin_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }

        private void numericUpDownCityLongArcsec_ValueChanged(object sender, EventArgs e)
        {
            calcSomething();
        }
    }
}

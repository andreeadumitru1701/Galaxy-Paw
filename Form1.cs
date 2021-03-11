using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startgame();
        }

        void startgame() //functie pentru inceputul jocului
        {
            label2.Visible = false; //initial label-ul game over, butonul restart si gloantele devin invizibile jucatorului
            restart.Visible = false;
            bullet1.Visible = false;
            bullet2.Visible = false;
            bullet3.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e) //timerul care controleaza functiile apelate jocului
        {
            enemymovement(gamespeed); //stabileste viteza jocului
            shotscollection(); //stabileste colectarea stelutelor ptr ammo
            enemy(gamespeed); //stabileste respawn-ul inamicilor dupa ce au disparut sau au fost distrusi
            kill(); //stabileste parametrii de distrugere a inamicilor de catre player
            gameover(); //stabileste parametri in care se incheie jocul si face posibil restartul
            shots(gamespeed); //stabileste respawn-ul stelutelor ptr ammo
        }

        Random r = new Random(); //variabila random ptr spawn
        
        int x; //axa de coordonate

        void enemymovement(int speed) //functie ptr stabilirea vitezei de joc
        {
            if (enemy1.Top >= 500)
            {
                enemy1.Top = 0;
            }
            else
            {
                enemy1.Top += speed; //incrementarea vitezei inamicilor
            }

            if (enemy2.Top >= 500)
            {
                enemy2.Top = 0;
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 500)
            {
                enemy3.Top = 0;
            }
            else
            {
                enemy3.Top += speed;
            }

            if (enemy4.Top >= 500)
            {
                enemy4.Top = 0;
            }
            else
            {
                enemy4.Top += speed;
            }

            if (enemy5.Top >= 500)
            {
                enemy5.Top = 0;
            }
            else
            {
                enemy5.Top += speed;
            }

            if (enemy6.Top >= 500)
            {
                enemy6.Top = 0;
            }
            else
            {
                enemy6.Top += speed;
            }
        }

        void shotscollection()
        {
            if (cat.Bounds.IntersectsWith(shot1.Bounds)) //daca playerul trece peste o stea
            {
                collectedshots++; //ammo creste
                label3.Text = "Shots:" + collectedshots.ToString(); //se modifica ammo astfel incat jucatorul vede
                x = r.Next(15, 875); // se stabileste urmatoarea locatie de spawn a stelei
                shot1.Location = new Point(x, 0); //steaua se spawneaza la noul punct
            }

            if (cat.Bounds.IntersectsWith(shot2.Bounds))
            {
                collectedshots++;
                label3.Text = "Shots:" + collectedshots.ToString();
                x = r.Next(15, 875);
                shot2.Location = new Point(x, 0);
            }

            if (cat.Bounds.IntersectsWith(shot3.Bounds))
            {
                collectedshots++;
                label3.Text = "Shots:" + collectedshots.ToString();
                x = r.Next(15, 875);
                shot3.Location = new Point(x, 0);
            }

            if (cat.Bounds.IntersectsWith(shot4.Bounds))
            {
                collectedshots++;
                label3.Text = "Shots:" + collectedshots.ToString();
                x = r.Next(15, 875);
                shot4.Location = new Point(x, 0);
            }

            if (cat.Bounds.IntersectsWith(shot5.Bounds))
            {
                collectedshots++;
                label3.Text = "Shots:" + collectedshots.ToString();
                x = r.Next(15, 875);
                shot5.Location = new Point(x, 0);
            }
        }

        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy1.Location = new Point(x, 0); //respawn-ul inamicilor
            }
            else
            {
                enemy1.Top += speed;
            }

            if (enemy2.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy2.Location = new Point(x, 0);
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy3.Location = new Point(x, 0);
            }
            else
            {
                enemy3.Top += speed;
            }

            if (enemy4.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy4.Location = new Point(x, 0);
            }
            else
            {
                enemy4.Top += speed;
            }

            if (enemy5.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy5.Location = new Point(x, 0);
            }
            else
            {
                enemy5.Top += speed;
            }

            if (enemy6.Top >= 500)
            {
                x = r.Next(15, 875);
                enemy6.Location = new Point(x, 0);
            }
            else
            {
                enemy6.Top += speed;
            }
            if (enemy1.Bounds.IntersectsWith(cat.Bounds)) //daca inamicii se intersecteaza cu playerul 'pisica'
            {
                cat.Image = Properties.Resources.explosion; //apare imaginea de explozie
                restart.Visible = true; //apare butonul de restart
                label2.Visible = true; //apare indicatorul Game Over
            }

            if (enemy2.Bounds.IntersectsWith(cat.Bounds))
            {
                cat.Image = Properties.Resources.explosion;
                restart.Visible = true;
                label2.Visible = true;
            }

            if (enemy3.Bounds.IntersectsWith(cat.Bounds))
            {
                cat.Image = Properties.Resources.explosion;
                restart.Visible = true;
                label2.Visible = true;
            }

            if (enemy4.Bounds.IntersectsWith(cat.Bounds))
            {
                cat.Image = Properties.Resources.explosion;
                restart.Visible = true;
                label2.Visible = true;
            }

            if (enemy5.Bounds.IntersectsWith(cat.Bounds))
            {
                cat.Image = Properties.Resources.explosion;
                restart.Visible = true;
                label2.Visible = true;
            }

            if (enemy6.Bounds.IntersectsWith(cat.Bounds))
            {
                cat.Image = Properties.Resources.explosion;
                restart.Visible = true;
                label2.Visible = true;
            }
        }

        int scor = 0; //evidenta scorului

        void kill() 
        {
            if ((bullet1.Bounds.IntersectsWith(enemy1.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy1.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy1.Bounds))) //cand glontul se intersecteaza cu inamicii
            {
                scor++; // scorul creste
                score.Text = "Score:" + scor.ToString(); //scorul este vizibil pentru player
                enemy1.Location = new Point(x, 0); //inamicul se respawneaza
                firee1.Enabled = false; //timer-ul pentru tragere inceteaza
                bullet1.Visible = false; //dispare imaginea glontului
            }

            else if ((bullet1.Bounds.IntersectsWith(enemy2.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy2.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy2.Bounds)))
            {
                scor++;
                score.Text = "Score:" + scor.ToString();
                enemy2.Location = new Point(x, 0);
                firee1.Enabled = false;
                bullet1.Visible = false;
            }

            else if ((bullet1.Bounds.IntersectsWith(enemy3.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy3.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy3.Bounds)))
            {
                scor++;
                score.Text = "Score:" + scor.ToString();
                enemy3.Location = new Point(x, 0);
                firee1.Enabled = false;
                bullet1.Visible = false;
            }

            else if ((bullet1.Bounds.IntersectsWith(enemy4.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy4.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy4.Bounds)))
            {
                scor++;
                score.Text = "Score:" + scor.ToString();
                enemy4.Location = new Point(x, 0);
                firee1.Enabled = false;
                bullet1.Visible = false;
            }

            else if ((bullet1.Bounds.IntersectsWith(enemy5.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy5.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy5.Bounds)))
            {
                scor++;
                score.Text = "Score:" + scor.ToString();
                enemy5.Location = new Point(x, 0);
                firee1.Enabled = false;
                bullet1.Visible = false;
            }

            else if ((bullet1.Bounds.IntersectsWith(enemy6.Bounds)) || (bullet2.Bounds.IntersectsWith(enemy6.Bounds)) || (bullet3.Bounds.IntersectsWith(enemy6.Bounds)))
            {
                scor++;
                score.Text = "Score:" + scor.ToString();
                enemy6.Location = new Point(x, 0);
                firee1.Enabled = false;
                bullet1.Visible = false;
            }
        }

        void shots(int speed)
        {
            if (shot1.Top >= 500)
            {
                x = r.Next(15, 875); //noua locatie de spawn a stelei
                shot1.Location = new Point(x, 0); //spawn-ul stelei
            }
            else
            {
                shot1.Top +=gamespeed; //steaua ia valoarea vitezei de joc
            }

            if (shot2.Top >= 500)
            {
                x = r.Next(15, 875);
                shot2.Location = new Point(x, 0);
            }
            else
            {
                shot2.Top += gamespeed;
            }

            if (shot3.Top >= 500)
            {
                x = r.Next(15, 875);
                shot3.Location = new Point(x, 0);
            }
            else
            {
                shot3.Top += gamespeed;
            }

            if (shot4.Top >= 500)
            {
                x = r.Next(15, 875);
                shot4.Location = new Point(x, 0);
            }
            else
            {
                shot4.Top += gamespeed;
            }

            if (shot5.Top >= 500)
            {
                x = r.Next(15, 875);
                shot5.Location = new Point(x, 0);
            }
            else
            {
                shot5.Top += gamespeed;
            } 
        }

        void gameover()
        {
            if (cat.Bounds.IntersectsWith(enemy1.Bounds)) //daca playerul 'pisica' se intersecteaza cu un inamic
            {
                timer1.Enabled = false; //functiile jocului inceteaza
                label2.Visible = true; //apare notificarea 'Game Over'
            }

            if (cat.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }

            if (cat.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }

            if (cat.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }

            if (cat.Bounds.IntersectsWith(enemy5.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }

            if (cat.Bounds.IntersectsWith(enemy6.Bounds))
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }
        }

        int collectedshots = 1; //variabila care pastreaza ammo

        int gamespeed = 1; //variabila care pastreaza viteza de joc

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //deplasarea controllerului 'pisica'

            if (e.KeyCode == Keys.Left)
            {
                if (cat.Left > 15) //setare margine stanga ptr a nu iesi din limitele ferestrei
                    cat.Left += -8;
            }

            if (e.KeyCode == Keys.Right)
            {
                if (cat.Left < 875) //setare margine dreapta ptr a nu iesi din limitele ferestrei
                    cat.Left += 8;
            }

            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 25)
                {
                    gamespeed++; //incrementarea vitezei de joc la apasarea tastei Up
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 1)
                {
                    gamespeed--; //decrementarea vitezei de joc la apasarea tastei Down
                }
            }

            if (e.KeyCode == Keys.Space) //setarea tastei Space pentru a trage
            {
                if (collectedshots > 0)
                {
                    if (collectedshots % 1 == 0) //se trage atata timp cat este ammo
                        {
                            bullet1.Location = cat.Location;
                            firee1.Enabled = true;
                            collectedshots--; //ammo scade dupa ce s-a tras
                            label3.Text = "Shots:" + collectedshots.ToString();
                        }

                        else if (collectedshots % 2 == 0)
                        {
                            bullet2.Location = cat.Location;
                            firee2.Enabled = true;
                            collectedshots--;
                            label3.Text = "Shots:" + collectedshots.ToString();
                        }

                        else if (collectedshots % 3 == 0)
                        {
                            bullet3.Location = cat.Location;
                            firee3.Enabled = true;
                            collectedshots--;
                            label3.Text = "Shots:" + collectedshots.ToString();
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart(); //restartarea aplicatiei la apasarea butonului Restart
        }

        private void shot1_Click(object sender, EventArgs e)
        {

        }

        private void firee1_Tick(object sender, EventArgs e)
        {
            bullet1.Visible = true; //cand timer-ul porneste, glontul devine vizibil
            bullet1.Top += -40; //viteza de deplasare a glontului
        }

        private void firee2_Tick(object sender, EventArgs e)
        {
            bullet2.Visible = true;
            bullet2.Top += -40;
        }

        private void firee3_Tick(object sender, EventArgs e)
        {
            bullet3.Visible = true;
            bullet3.Top += -40;
        }
    } 
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TheQuest
{
    public partial class theQuest : Form
    {
        private Game game;
        private Random random = new Random();

        public theQuest()
        {
            InitializeComponent();

        }

        public void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            playerHitPoints.Text =
                game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            // Check if enemies are still alive.  If so, set their show variable to true.
            foreach(Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }

                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }

            //Sets visibility of enemy objects based on conditions above
            if (showBat == false)
            {
                bat.Visible = false;
                batHitPoints.Visible = false;
                batLabel.Visible = false;
            }
            else
            {
                bat.Visible = true;
                batHitPoints.Visible = true;
                batLabel.Visible = true;
            }

            if (showGhost == false)
            {
                ghost.Visible = false;
                ghostHitPoints.Visible = false;
                ghostLabel.Visible = false;
            }
            else
            {
                ghost.Visible = true;
                ghostHitPoints.Visible = true;
                ghostLabel.Visible = true;
            }

            if (showGhoul == false)
            {
                ghoul.Visible = false;
                ghoulHitPoints.Visible = false;
                ghoulLabel.Visible = false;
            }
            else
            {
                ghoul.Visible = true;
                ghoulHitPoints.Visible = true;
                ghoulLabel.Visible = false;
            }

            // Makes weapon icons invisible in game window
            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;

            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword; break;
                case "Bow":
                    weaponControl = bow; break;
                case "Red Potion":
                    weaponControl = redPotion; break;
                case "Blue Potion":
                    weaponControl = bluePotion; break;
                case "Mace":
                    weaponControl = mace; break;
            }
            weaponControl.Visible = true;

            //Setting intitial attack button text and visibility
            attackUp.Text = "↑";
            attackRight.Visible = true;
            attackDown.Visible = true;
            attackLeft.Visible = true;

            //Setting weapon inventory visibility in game window
            if (game.CheckPlayerInventory("Sword"))
                swordInventory.Visible = true;
            else
                swordInventory.Visible = false;

            if (game.CheckPlayerInventory("Bow"))
                bowInventory.Visible = true;
            else
                bowInventory.Visible = false;

            if (game.CheckPlayerInventory("Mace"))
                maceInventory.Visible = true;
            else
                maceInventory.Visible = false;

            if (game.CheckPlayerInventory("Blue Potion"))
                bluePotionInventory.Visible = true;
            else
                bluePotionInventory.Visible = false;

            if (game.CheckPlayerInventory("Red Potion"))
                redPotionInventory.Visible = true;
            else
                redPotionInventory.Visible = false;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }


            if (enemiesShown < 1 && game.Level < 8)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void swordInventory_Click(object sender, EventArgs e)
        {
            if(game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
            }

            swordInventory.BorderStyle = BorderStyle.Fixed3D;
            bowInventory.BorderStyle = BorderStyle.None;
            maceInventory.BorderStyle = BorderStyle.None;
            bluePotionInventory.BorderStyle = BorderStyle.None;
            redPotionInventory.BorderStyle = BorderStyle.None;
        }

        private void bowInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
            }

            swordInventory.BorderStyle = BorderStyle.None;
            bowInventory.BorderStyle = BorderStyle.Fixed3D;
            maceInventory.BorderStyle = BorderStyle.None;
            bluePotionInventory.BorderStyle = BorderStyle.None;
            redPotionInventory.BorderStyle = BorderStyle.None;
        }

        private void maceInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
            }

            swordInventory.BorderStyle = BorderStyle.None;
            bowInventory.BorderStyle = BorderStyle.None;
            maceInventory.BorderStyle = BorderStyle.Fixed3D;
            bluePotionInventory.BorderStyle = BorderStyle.None;
            redPotionInventory.BorderStyle = BorderStyle.None;
        }

        private void bluePotionInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
            }

            swordInventory.BorderStyle = BorderStyle.None;
            bowInventory.BorderStyle = BorderStyle.None;
            maceInventory.BorderStyle = BorderStyle.None;
            bluePotionInventory.BorderStyle = BorderStyle.Fixed3D;
            redPotionInventory.BorderStyle = BorderStyle.None;

            //Changes attack button visibility so player can drink potion
            attackUp.Text = "Drink";
            attackRight.Visible = false;
            attackDown.Visible = false;
            attackLeft.Visible = false;
        }
        
        private void redPotionInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
            }

            swordInventory.BorderStyle = BorderStyle.None;
            bowInventory.BorderStyle = BorderStyle.None;
            maceInventory.BorderStyle = BorderStyle.None;
            bluePotionInventory.BorderStyle = BorderStyle.None;
            redPotionInventory.BorderStyle = BorderStyle.Fixed3D;

            //Changes attack button visibility so player can drink potion
            attackUp.Text = "Drink";
            attackRight.Visible = false;
            attackDown.Visible = false;
            attackLeft.Visible = false;
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void theQuest_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(72, 57, 400, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }
    }
}

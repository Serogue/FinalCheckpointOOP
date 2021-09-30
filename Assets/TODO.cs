//Player chooses a ship out of several
//Each playable ship has different stats
//Ship 1 - faster maneuvers but less hull
//Ship 2 - slower maneuvers but more hull

//Player is on the left side of the screen, can change X and Y, always the same direction
//Background is infinitely scrolling from right to left ++
//Player can shoot, lose hull if hit by an enemy projectile or ship
//Several enemy types ships spawn on the right side of the screen

//Each enemy type has own stats
//Enemy 0 - kamikaze (missile type), destroy player's ship on collision, flies in one trajectory
//Enemy 1 - shooting, can change Y position (following player's Y), flies in one trajectory
//Enemy 2 - shooting, rotating towards the player, can change trajectory
//Enemy 3 - boss of some kind, stays on screen until defeated, laser beam attack

//Pickups of several type spawn randomly:
//Hull - restores player's health
//Double Power - temporary boost of fire power

//Game manager tracking the HiScore and player name, saving settings (music volume)
//Settings - music volume (+ disable option), "Reset all" button
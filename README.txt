BUSTER: A Tile-Based Platformer

Advice from higherorderfun.com/blog/2012/05/20/the-guide-to-implementing-2d-platformers/

Unity's physics engine is severely lacking for platformers in 2d (it's like using a jackhammer to hit a nail). Buster will use a custom "engine" to try and make high quality-ness easier to achieve.

Map storage: each tile stores data on if it's an obstacle, its sprite, and other metadata.
Player: Axis Aligned Bounding Box (non-rotating rectangle). Make the sprite bigger than the hitbox.
slopes: have the tile store a "floor y" of either side, and some weird black magic to solve


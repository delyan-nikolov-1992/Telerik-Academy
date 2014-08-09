$(document).ready(function () {

    mapLayer = new Layer('#root', {
        width: TILE_SIZE * LEVEL_COLS,
        height: TILE_SIZE * LEVEL_ROWS,
        id: 'map'
    }).init();

    var heroLayer = new Layer('#root', {
        width: TILE_SIZE * LEVEL_COLS,
        height: TILE_SIZE * LEVEL_ROWS,
        id: 'heroLayer'
    }).init();

    renderLevel(mapLayer);

    var playerXPos = PLAYER_ROW * TILE_SIZE;
    var playerYPos = PLAYER_COL * TILE_SIZE;
    hero = new GameCharacter(heroLayer, playerXPos, playerYPos, player_COLOR, CHARACTERISTIC.Player).drawPlayer();

    engine(heroLayer, {
        hero: hero
    });

});
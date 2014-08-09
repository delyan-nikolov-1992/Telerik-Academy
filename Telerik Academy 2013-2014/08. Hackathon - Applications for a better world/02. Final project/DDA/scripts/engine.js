function engine(layer, objects) {
    PLAYER_X_SPEED = 0;
    PLAYER_Y_SPEED = 0;

    if (RIGHT_PRESSED || LEFT_PRESSED || UP_PRESSED || DOWN_PRESSED) {
        $('#questionBox').hide();
    }

    if (RIGHT_PRESSED) {
        PLAYER_X_SPEED = MOVEMENT_SPEED;
    }
    if (LEFT_PRESSED) {
        PLAYER_X_SPEED = -MOVEMENT_SPEED;
    }
    if (UP_PRESSED) {
        PLAYER_Y_SPEED = -MOVEMENT_SPEED;
    }
    if (DOWN_PRESSED) {
        PLAYER_Y_SPEED = MOVEMENT_SPEED;
    }

    objects.hero.x += PLAYER_X_SPEED;
    objects.hero.y += PLAYER_Y_SPEED;

    // Collision Detection
    var baseCol = Math.floor(objects.hero.x / TILE_SIZE);
    var baseRow = Math.floor(objects.hero.y / TILE_SIZE);
    var colOverlap = objects.hero.x % TILE_SIZE;
    var rowOverlap = objects.hero.y % TILE_SIZE;

    if (PLAYER_X_SPEED > 0) {
        if ((LEVEL[baseRow][baseCol + 1] && !LEVEL[baseRow][baseCol]) || (LEVEL[baseRow + 1][baseCol + 1] && !LEVEL[baseRow + 1][baseCol] && rowOverlap)) {
            objects.hero.x = baseCol * TILE_SIZE;
        }
    }

    if (PLAYER_X_SPEED < 0) {
        if ((!LEVEL[baseRow][baseCol + 1] && LEVEL[baseRow][baseCol]) || (!LEVEL[baseRow + 1][baseCol + 1] && LEVEL[baseRow + 1][baseCol] && rowOverlap)) {
            objects.hero.x = (baseCol + 1) * TILE_SIZE;
        }
    }

    // check for vertical collisions

    baseCol = Math.floor(objects.hero.x / TILE_SIZE);
    baseRow = Math.floor(objects.hero.y / TILE_SIZE);
    colOverlap = objects.hero.x % TILE_SIZE;
    rowOverlap = objects.hero.y % TILE_SIZE;

    if (PLAYER_Y_SPEED > 0) {
        if ((LEVEL[baseRow + 1][baseCol] && !LEVEL[baseRow][baseCol]) || (LEVEL[baseRow + 1][baseCol + 1] && !LEVEL[baseRow][baseCol + 1] && colOverlap)) {
            objects.hero.y = baseRow * TILE_SIZE;
        }
    }

    if (PLAYER_Y_SPEED < 0) {
        if ((!LEVEL[baseRow + 1][baseCol] && LEVEL[baseRow][baseCol]) || (!LEVEL[baseRow + 1][baseCol + 1] && LEVEL[baseRow][baseCol + 1] && colOverlap)) {
            objects.hero.y = (baseRow + 1) * TILE_SIZE;
        }
    }
    // Collision Detection END

    layer.clearRect(0, 0, layer.canvas.width, layer.canvas.height);
    objects.hero.drawPlayer();

    requestAnimationFrame(function () {
        engine(layer, objects);
    });
}
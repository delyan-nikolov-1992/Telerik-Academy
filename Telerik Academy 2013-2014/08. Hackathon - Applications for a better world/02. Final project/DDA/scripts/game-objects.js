function Layer(parent, options) {
    this.width = options.width;
    this.height = options.height;
    this.id = options.id || 'unknown';
    this.parent = parent;
    var self = this;
    this.init = function () {
        var canvas = document.createElement('canvas');
        canvas.width = self.width;
        canvas.height = self.height;
        canvas.id = self.id;
        var parent = document.querySelector(self.parent);
        parent.appendChild(canvas);
        return canvas.getContext('2d');
    }
}

function GameCharacter(layer, x, y, color, characteristic, valueable) {
    this.layer = layer;
    this.x = x;
    this.y = y;
    this.w = player_SIZE.w;
    this.h = player_SIZE.h;
    this.characteristic = characteristic;
    this.color = color;
    this.sportPoints = 0;
    this.historyPoints = 0;
    this.biologyPoints = 0;
    this.chemistryPoints = 0;
    this.programmingPoints = 0;
    this.valueable = valueable;
    this.title = 'Person';
    var self = this;
    this.drawPlayer = function () {
        if(self.characteristic === -1){
            drawCircle(self.layer, self.x + (this.w / 2), self.y + (this.w / 2), this.w / 2.5, 'black');
            drawCircle(self.layer, self.x + (this.w / 2), self.y + (this.w / 2), this.w / 3, this.color);
            drawCircle(self.layer, self.x + (this.w / 3.2), self.y + (this.w / 2.5), this.w / 12, 'black');
            drawCircle(self.layer, self.x + (this.w / 1.7), self.y + (this.w / 2.5), this.w / 12, 'black');
        }
        else {
            drawCircle(self.layer, self.x + (this.w / 2), self.y + (this.w / 2), this.w / 2, this.color);
            drawCircle(self.layer, self.x + (this.w / 3.5), self.y + (this.w / 2.5), this.w / 10, 'black');
            drawCircle(self.layer, self.x + (this.w / 1.7), self.y + (this.w / 2.5), this.w / 10, 'black');
        }
        return self;
    };
    this.interactWithGameObject = function () {

        var baseCol = Math.floor((self.x + (self.w / 2)) / TILE_SIZE);
        var baseRow = Math.floor((self.y + (self.w / 2)) / TILE_SIZE);


        if (LEVEL[baseRow - 1][baseCol] instanceof GameCharacter) { // Check top
            showQuestion(LEVEL[baseRow - 1][baseCol], baseRow - 1, baseCol);
        } else if (LEVEL[baseRow - 1][baseCol + 1] instanceof GameCharacter) { // Check topRight
            showQuestion(LEVEL[baseRow - 1][baseCol + 1], baseRow - 1, baseCol + 1);
        } else if (LEVEL[baseRow][baseCol + 1] instanceof GameCharacter) { // Check Right
            showQuestion(LEVEL[baseRow][baseCol + 1], baseRow, baseCol + 1);
        } else if (LEVEL[baseRow + 1][baseCol + 1] instanceof GameCharacter) { // Check rightDown
            showQuestion(LEVEL[baseRow + 1][baseCol + 1], baseRow + 1, baseCol + 1);
        } else if (LEVEL[baseRow + 1][baseCol] instanceof GameCharacter) { // Check Down
            showQuestion(LEVEL[baseRow + 1][baseCol], baseRow + 1, baseCol);
        } else if (LEVEL[baseRow + 1][baseCol - 1] instanceof GameCharacter) { // Check DownLeft
            showQuestion(LEVEL[baseRow + 1][baseCol - 1], baseRow + 1, baseCol - 1);
        } else if (LEVEL[baseRow][baseCol - 1] instanceof GameCharacter) { // Check Left
            showQuestion(LEVEL[baseRow][baseCol - 1], baseRow, baseCol - 1);
        } else if (LEVEL[baseRow - 1][baseCol - 1] instanceof GameCharacter) { // Check topLeft
            showQuestion(LEVEL[baseRow - 1][baseCol - 1], baseRow - 1, baseCol - 1);
        }
    }
};
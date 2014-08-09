function onCheckThirdBitBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        position = 3,
        mask = 1 << position,
        numberAndMask = number & mask,
        bit = numberAndMask >> position;

    jsConsole.writeLine(bit);
}
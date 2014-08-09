/// <reference path="jquery-1.11.1.min.js" />
function showQuestion(gameCharacter, row, col) {
    //Ajax
    /*var questionData = {
        question: "Who am I?",
        correct: 0,
        answers: [
            "Dido",
            "LeBron James",
            "ninja",
            "e oniq pi4"
        ]
    };*/
    var questionData;

    $('#information').hide();
    $.ajax({
        type: 'POST',
        url: 'php/getQuestionIDs.php',
        data: { questionType: gameCharacter.characteristic + 1 }
    }).done(function (data) {
        var json = JSON.parse(data);
        var randomIndex = Math.floor(Math.random() * json.length);
        var questionId = parseInt(json[randomIndex]);
        $.ajax({
            type: 'POST',
            url: 'php/getQuestion.php',
            data: { questionId: questionId }
        }).done(function (data) {
            questionData = JSON.parse(data);

            var answers = document.getElementsByClassName('answers');
            $('.answers').off();

            for (var j = 0; j < 4; j++) {
                answers[j].style.backgroundColor = '#C0C0C0';
            }

            document.getElementById('questionBox').style.display = 'block';

            var questionTitle = document.getElementById('question');
            questionTitle.innerText = questionData.question;

            for (var i = 0; i < questionData.answers.length; i++) {
                var currentAnswer = document.getElementById(i + '-answer');
                currentAnswer.innerText = questionData.answers[i];

                $(currentAnswer).on('click', function () {
                    var $this = $(this);

                    for (var j = 0; j < 4; j++) {
                        if (answers[j].id.substr(0, 1) == questionData.correct) {
                            answers[j].style.backgroundColor = 'green';
                        } else {
                            answers[j].style.backgroundColor = 'red';
                        }
                    }

                    if (this.id.substr(0, 1) == questionData.correct) {
                        switch (gameCharacter.characteristic) {
                            case 0:
                                hero.sportPoints++;
                                printStatistics($this, hero.sportPoints, 0);
                                break;
                            case 1:
                                hero.historyPoints++;
                                printStatistics($this, hero.historyPoints, 1);
                                break;
                            case 2:
                                hero.biologyPoints++;
                                printStatistics($this, hero.biologyPoints, 2);
                                break;
                            case 3:
                                hero.chemistryPoints++;
                                printStatistics($this, hero.chemistryPoints, 3);
                                break;
                            case 4:
                                hero.programmingPoints++;
                                printStatistics($this, hero.programmingPoints, 4);

                                if (hero.programmingPoints === 1) {
                                    $this.parent().parent().find('#statistics span:nth-of-type(6)').text('Baby Dev');
                                    $('#star-rating').css('width', '32px');
                                }
                                else if (hero.programmingPoints === 2) {
                                    $this.parent().parent().find('#statistics span:nth-of-type(6)').text('Junior Dev');
                                    $('#star-rating').css('width', '64px');
                                }
                                else if (hero.programmingPoints === 3) {
                                    $this.parent().parent().find('#statistics span:nth-of-type(6)').text('Dev');
                                    $('#star-rating').css('width', '96px');
                                }

                                break;
                        }
                         if (LEVEL[row][col].valueable) {
                            LEVEL[12][10] = 0;
                            renderCell(mapLayer, 12, 10);
                            LEVEL[13][10] = 0;
                            renderCell(mapLayer, 13, 10);
                            LEVEL[12][11] = 0;
                            renderCell(mapLayer, 12, 11);
                            LEVEL[13][11] = 0;
                            renderCell(mapLayer, 13, 11);
                        }
                    }

                    var infoBox = document.getElementById('information');
                    infoBox.innerHTML = '<strong>Information:</strong> ' + questionData.information;
                    $('#information').show();


                    $('button').off();

                   

                    LEVEL[row][col] = 0;
                    renderCell(mapLayer, row, col);
                })
            }
        });
    });

    function printStatistics($this, characteristic, index) {
        $this.parent().parent().find('#statistics span:nth-of-type(' + (index + 1) + ')').text(characteristic);
    }
}
//
//  Game.cpp
//  Test
//
//  Created by diego on 1/31/15.
//  Copyright (c) 2015 Diego. All rights reserved.
//

#include "Game.h"


bool NoteQuestion::testAnswer(int Input){
    return (Input == answerIndex);
}


NoteQuestion::NoteQuestion(){
    //Set the answer
    srand(time(NULL));
    answerIndex = ((rand()%4)+100)%4;
    
    answers[answerIndex].level = (((rand()%2)+100)%2)-1;
    
    switch(answers[answerIndex].level){
        case -1:{
            answers[answerIndex].noteKey = (key)(((rand()%5)+100)%5 + C);
            break;
        }
        case 0:{
            answers[answerIndex].noteKey = (key)(((rand()%6)+102)%6 + A);
            break;
        }
    }
    
    answers[answerIndex].noteType = (type)(((rand()%3)+99)%3 + sharp);

    //set the other answers
    for(int i = 0; i < 4; i = i + 1){
        if(i != answerIndex){
            answers[i].noteType = answers[answerIndex].noteType;
            answers[i].noteKey = (key)((((rand()%7)+77)%7)+A);
        }
    }
    
}

void NoteQuestion::newQuestion(){
    //Set the answer
    srand(time(NULL));
    int oldIndex = answerIndex;
    answerIndex = ((rand()%4)+100)%4;
    
    answers[answerIndex].level = ((((answers[oldIndex].level+rand())%2)+100)%2)-1;
    
    switch(answers[answerIndex].level){
        case -1:{
            answers[answerIndex].noteKey = (key)((((answers[oldIndex].noteKey+rand())%5)+100)%5 + C);
            break;
        }
        case 0:{
            answers[answerIndex].noteKey = (key)((((answers[oldIndex].noteKey+rand())%6)+102)%6 + A);
            break;
        }
    }
    
    answers[answerIndex].noteType = (type)((((answers[oldIndex].noteType+rand())%3)+99)%3 + sharp);
    
    //set the other answers
    for(int i = 0; i < 4; i = i + 1){
        if(i != answerIndex){
            answers[i].noteType = answers[answerIndex].noteType;
            answers[i].noteKey = (key)((((rand()%7)+77)%7)+A);
        }
    }
}

note NoteQuestion::getAnswer(){
    note Temp;
    Temp.noteKey = answers[answerIndex].noteKey;
    Temp.level = answers[answerIndex].level;
    Temp.noteType = answers[answerIndex].noteType;
    
    return Temp;
}

std::string NoteQuestion::getInput(int index){
    std::string input = "";
    
    switch(answers[index].noteType){
        case sharp:{
            input = input + "#";
            break;
        }
        case flat:{
            input = input + "b";
            break;
        }
        case natural:{
            break;
        }
        
    }
    switch(answers[index].noteKey){
        case A:{
            input = input + "A";
            break;
        }
        case B:{
            input = input + "B";
            break;
        }
        case C:{
            input = input + "C";
            break;
        }
        case D:{
            input = input + "D";
            break;
        }
        case E:{
            input = input + "E";
            break;
        }
        case F:{
            input = input + "F";
            break;
        }
        case G:{
            input = input + "G";
            break;
        }
    }
    return input;
}


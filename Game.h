//
//  Game.h
//  Test
//
//  Created by diego on 1/31/15.
//  Copyright (c) 2015 Diego. All rights reserved.
//

#ifndef __Test__Game__
#define __Test__Game__

#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <string.h>
#include <random>

enum key{ A,B,C,D,E,F,G};
enum type{ sharp, natural, flat};
enum chordType{ maj, min};

struct note{
    key noteKey;
    int level;
    type noteType;
};

struct chord{
    key root;
    chordType Type;
};

class NoteQuestion{
private:
    
    note answers[4];//Fake Answers for the question
    int answerIndex;//integer index

public:
    NoteQuestion();//Pick a random note and random distinct fake answers
    bool testAnswer(int Input);
    void newQuestion();//Redoes the question
    note getAnswer();
    std::string getInput(int index);
};

class ChordQuestion{
    
};

class ScaleQuestion{
    
};


#endif /* defined(__Test__Game__) */

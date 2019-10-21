#pragma once
#ifndef ROOM_H
#define ROOM_H
#include "BasicObject.h"
class Room : public BasicObject
{
	
public:
	Room();
	~Room();
	void initialize();
	void look();
};
#endif
#pragma once
#ifndef ROOM_H
#define ROOM_H
#include <string>
#include <map>
#include "BasicObject.h"
class Room : public BasicObject
{
	std::map<int, Room*> mExitRooms;
public:
	Room();
	~Room();
	const void AddExitRoom(Room*);
	void RemoveExitRoom(Room*);
};
#endif
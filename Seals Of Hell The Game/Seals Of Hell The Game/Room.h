#pragma once
#ifndef ROOM_H
#define ROOM_H
#include <string>
#include "BasicObject.h"
class Room : public BasicObject
{
	
public:
	Room();
	~Room();
	virtual std::string& getName() override { return mName; }
	virtual std::string& getStory() override { return mStory; }
	virtual int& getUniqueID() override { return mUniqueID; }
};
#endif
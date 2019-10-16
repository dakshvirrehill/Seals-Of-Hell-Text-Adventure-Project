#pragma once
#ifndef ROOM_H
#define ROOM_H
#include <string>
class Room
{
	std::string mName;
	std::string mStory;
public:
	Room();
	~Room();
	std::string& getName() { return mName; }
	std::string& getStory() { return mStory; }
};
#endif
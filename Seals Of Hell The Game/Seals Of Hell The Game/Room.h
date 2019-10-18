#pragma once
#ifndef ROOM_H
#define ROOM_H
#include <string>
#include <map>
#include "BasicObject.h"
namespace json
{
	class JSON;
}
class Room : public BasicObject
{
	
public:
	Room();
	~Room();
	void initialize(json::JSON&);
};
#endif
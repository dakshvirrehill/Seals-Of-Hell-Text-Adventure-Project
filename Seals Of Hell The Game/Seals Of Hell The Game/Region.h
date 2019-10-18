#pragma once
#ifndef REGION_H
#define REGION_H
#include <string>
#include "BasicObject.h"
class Room;
namespace json
{
	class JSON;
}
class Region : public BasicObject
{
	
public:
	Region();
	~Region();
	void initialize(json::JSON&);
};
#endif
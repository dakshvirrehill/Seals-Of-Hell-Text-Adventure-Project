#pragma once
#ifndef REGION_H
#define REGION_H
#include "BasicObject.h"
class Room;
class Region : public BasicObject
{
	
public:
	Region();
	~Region();
	void initialize();
};
#endif
#include "Region.h"
Region::Region()
	:BasicObject(),mEntryRoom(nullptr),mExitRoom(nullptr)
{
}

Region::~Region()
{
	if (mEntryRoom != nullptr)
	{
		delete mEntryRoom;
	}
	if (mExitRoom != nullptr)
	{
		delete mExitRoom;
	}
}

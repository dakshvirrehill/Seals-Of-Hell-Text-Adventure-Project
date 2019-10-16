#include "Region.h"

Region::Region()
	:mName(""),mStory(""),mEntryRoom(nullptr),mExitRoom(nullptr)
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

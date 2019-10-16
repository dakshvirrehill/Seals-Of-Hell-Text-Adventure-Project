#include "BasicObject.h"

BasicObject::BasicObject()
	:mName(""),mStory(""),mUniqueID(-1)
{
}

BasicObject::~BasicObject()
{
}

void BasicObject::Initialize(std::string& pName, std::string& pStory, int& pUniqueID)
{
	mName = pName;
	mStory = pStory;
	mUniqueID = pUniqueID;
}

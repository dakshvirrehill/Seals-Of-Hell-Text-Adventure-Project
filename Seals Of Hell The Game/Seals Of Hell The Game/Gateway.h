#pragma once
#ifndef GATEWAY_H
#define GATEWAY_H
#include "IInteractable.h"
class Room;
class Gateway : public IInteractable
{
	Room* mCurrentRoom;
	Room* mConnectedRoom;
	bool mInitialized;
public:
	Gateway() : IInteractable(), mCurrentRoom(nullptr), mConnectedRoom(nullptr),mInitialized(false) {}
	~Gateway();
	void initialize(Room*,Room*,bool);
	void setCurrentRoom(Room*);
	void lookObject() override;
	void goDirection() override;
	bool& isInitialized() { return mInitialized; }
	bool isGateway() override{ return mCurrentRoom != nullptr; }
	Room* getCurrentRoom() { return mCurrentRoom; }
	Room* getConnectedRoom() { return mConnectedRoom; }
};
#endif
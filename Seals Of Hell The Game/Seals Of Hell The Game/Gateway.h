#pragma once
#ifndef GATEWAY_H
#define GATEWAY_H
#include "IInteractable.h"
class Room;
/*
################
THE GATEWAY INTERACTABLE IS RESPONSIBLE FOR TRAVERSING IN ROOMS
IT HAS TWO POINTERS, ONE FOR CURRENT AND ONE FOR CONNECTING ROOM
IT SWAPS THESE POINTERS ONCE USED. THE ROOM ITS IN SETS ITSELF AS
CURRENT ROOM ON ENTER ROOM
################
*/
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
	json::JSON getItemJSON() override;
	std::string getType() override { return "Gateway"; }
	void resetGateway();
};
#endif
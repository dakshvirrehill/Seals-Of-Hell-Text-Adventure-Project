#pragma once
#ifndef GAME_MANAGER_H
#define GAME_MANAGER_H
#include <string>
#include "BasicObject.h"
class Region;
class Room;
class IInteractable;
class PlayerManager;
class GameManager : public BasicObject
{

private:
	std::string mFileName;
	Region* mCurrentRegion;
	Room* mCurrentRoom;
	PlayerManager* mCurrentPlayer;
	bool mGamePlay;
	inline explicit GameManager() :BasicObject(), mFileName(""), mCurrentRegion(nullptr), mCurrentRoom(nullptr), mCurrentPlayer(nullptr), mGamePlay(false) {}
	inline ~GameManager() {}
	inline explicit GameManager(GameManager const&) :BasicObject(), mFileName(""), mCurrentRegion(nullptr), mCurrentRoom(nullptr), mCurrentPlayer(nullptr), mGamePlay(false) {}
	inline GameManager& operator=(GameManager const&) 
	{
		return *this;
	}
protected:
	static void endGame();
	static void saveGame();
	static void inventory();
	static void look();
public:
	inline static GameManager& instance() 
	{
		static GameManager mInstance;
		return mInstance;
	}
	void lookInsideRoom();
	void initialize(Region*, Room*);
	void StartGame(std::string&);
	void GameLoop();
	void playerWon();
	void setCurrentRegion(Region*);
	void setCurrentRoom(Room*);
	IInteractable* getInteractable(std::string&);
	void removeFromRoom(IInteractable*);
	void addInRoom(IInteractable*);
	//player functions
	IInteractable* getInventoryObject(std::string&);
	void addInInventory(IInteractable*);
	void removeFromInventory(IInteractable*);
	void attackPlayer(IInteractable*);
	void dropInventory(Room*);
	void blockAttack();
	bool hasShield();
	bool hasInInventory(IInteractable*);
	void addNewShield(std::string);


	friend class CommandManager;
};
#endif
#pragma once
#ifndef GAME_MANAGER_H
#define GAME_MANAGER_H
#include <string>
class Region;
class Room;
class GameManager
{
	Region* mCurrentRegion;
	Room* mCurrentRoom;
private:
	std::string mFileName;
	inline explicit GameManager() : mCurrentRegion(nullptr),mCurrentRoom(nullptr) {}
	inline ~GameManager() {}
	inline explicit GameManager(GameManager const&) : mCurrentRegion(nullptr), mCurrentRoom(nullptr) {}
	inline GameManager& operator=(GameManager const&) 
	{
		return *this;
	}
protected:
	void look();
public:
	inline static GameManager& instance() 
	{
		static GameManager mInstance;
		return mInstance;
	}
	void StartGame(std::string&);
	void GameLoop();
	friend class CommandManager;
};
#endif
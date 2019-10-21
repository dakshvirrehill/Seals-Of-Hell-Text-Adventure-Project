#pragma once
#ifndef GAME_MANAGER_H
#define GAME_MANAGER_H
#include <string>
class BasicObject;
class Region;
class Room;
class GameManager : public BasicObject
{

private:
	std::string mFileName;
	Region* mCurrentRegion;
	Room* mCurrentRoom;
	bool mGamePlay;
	inline explicit GameManager() :BasicObject(), mFileName(""), mCurrentRegion(nullptr), mCurrentRoom(nullptr), mGamePlay(false) {}
	inline ~GameManager() {}
	inline explicit GameManager(GameManager const&) :BasicObject(), mFileName(""), mCurrentRegion(nullptr), mCurrentRoom(nullptr), mGamePlay(false) {}
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
	void EndGame();
	void SaveGame();
	friend class CommandManager;
};
#endif
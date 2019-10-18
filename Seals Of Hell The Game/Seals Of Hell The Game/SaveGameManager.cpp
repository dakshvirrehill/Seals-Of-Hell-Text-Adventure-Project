#include "SaveGameManager.h"
#include "json.hpp"
#include <string>
#include <fstream>
json::JSON& SaveGameManager::loadGame(std::string& pFileName)
{
	std::ifstream aInputStream(pFileName);
	std::string aReadJSON((std::istreambuf_iterator<char>(aInputStream)), std::istreambuf_iterator<char>());
	_ASSERT_EXPR(!aReadJSON.empty(), "Couldn't load save file. File Name = " + pFileName);
	json::JSON aJSONObj = json::JSON::Load(aReadJSON);
	return aJSONObj;
}

bool SaveGameManager::saveGame(json::JSON& pJson , std::string& pFileName)
{
	std::string aWriteJSON = pJson.dump();
	_ASSERT_EXPR(!aWriteJSON.empty(), "JSON String dump empty");
	std::ofstream aOutputStream(pFileName);
	_ASSERT_EXPR(aOutputStream.is_open(), "Couldn't open save file. File Name = " + pFileName);
	aOutputStream << aWriteJSON;
	return true;
}

docker stop edhutil-discord
docker rm edhutil-discord
docker build ./Models -t edhutil-models:latest
docker build ./DiscordBot -t edhutil-discord:latest
docker run --name edhutil-discord -d edhutil-discord:latest


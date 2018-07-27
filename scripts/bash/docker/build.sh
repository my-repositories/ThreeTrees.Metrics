#!/usr/bin/env bash

set -e
set -u

# or another docker image (for example: crmdb)
IMAGE=${1:-crmweb}

ln -sf $(pwd)/docker/$IMAGE/.dockerignore $(pwd)/.dockerignore

docker build --rm --no-cache -t $IMAGE -f ./docker/$IMAGE/Dockerfile .
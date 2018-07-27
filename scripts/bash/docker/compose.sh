#!/usr/bin/env bash

set -e
set -u

(cd ./docker/ && docker-compose -f docker-compose.yml up -d)

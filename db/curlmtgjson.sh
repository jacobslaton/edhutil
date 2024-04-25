#!/bin/bash

# Crude check to determine if we want to use the json file already on disk.
if [ $# -lt 1 ] || [ $1 != "--use-cache" ]; then
    echo "Downloading AllPrintings.json..."
    rm -f AllPrintings.json
    curl https://mtgjson.com/api/v5/AllPrintings.json.gz -o AllPrintings.json.gz
    gunzip AllPrintings.json.gz
fi
python3 xnf.py
cat ddl.sql > AllPrintings.sql
cat dml.sql >> AllPrintings.sql


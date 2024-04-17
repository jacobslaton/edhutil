rm -f AllPrintings.json
curl https://mtgjson.com/api/v5/AllPrintings.json.gz -o AllPrintings.json.gz
gunzip AllPrintings.json.gz
python3 xnf.py
cat ddl.sql > AllPrintings.sql
cat dml.sql >> AllPrintings.sql


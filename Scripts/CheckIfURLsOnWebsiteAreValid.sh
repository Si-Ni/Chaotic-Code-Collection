#!/bin/bash

RED='\033[0;31m'
NC='\033[0m'

# Check if the number of command line parameters is not equal to 1
if [ $# -ne 1 ]; then
	echo -e "${RED}Error: Exactly one parameter is required (URL)"
    exit 1
fi

URL=$1

echo -e "${NC}Curling html page from $1...\n"
curl -o /tmp/curledHTMLPage.html $1 >> /dev/null 2>&1

html_file="/tmp/curledHTMLPage.html"

if [ ! -f "$html_file" ]; then
  echo -e "${RED}Error: HTML file not found.${NC}"
  exit 1
fi

links=$(grep -o 'href="h[^"]*"' "$html_file" | sed 's/href="//;s/"//')

echo -e "${NC}Checking links...\n"

for link in $links; do
  wget --spider -q "$link"
  status=$?

  echo -e "${NC}Checking link: $link"

  if [ $status -ne 0 ]; then
    echo -e "${RED}Invalid link: $link${NC}"
  fi
done

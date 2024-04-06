import json

all_printings = None
with open("AllPrintings.json", "r") as fin:
    all_printings = json.load(fin)

# Drop unwanted data.
for set_code in all_printings["data"].keys():
    all_printings["data"][set_code].pop("booster", None)

all_printings["artists"] = {}
all_printings["cards"] = []
all_printings["finishes"] = []
all_printings["frame_effects"] = []
all_printings["keywords"] = []
all_printings["promo_types"] = []
all_printings["rulings"] = {}
all_printings["subsets"] = []
all_printings["subtypes"] = []
all_printings["supertypes"] = []
all_printings["types"] = []
all_printings["map_cards_artists" ] = {}
all_printings["map_cards_attraction_lights"] = {}
all_printings["map_cards_color_identity"] = {}
all_printings["map_cards_color_indicators"] = {}
all_printings["map_cards_colors"] = {}
all_printings["map_cards_finishes"] = []
all_printings["map_cards_frame_effects"] = {}
all_printings["map_cards_keywords"] = {}
all_printings["map_cards_other_face_ids"] = []
all_printings["map_cards_promo_types"] = {}
all_printings["map_cards_rulings"] = {}
all_printings["map_cards_sets_variations"] = []
all_printings["map_cards_subsets"] = {}
all_printings["map_cards_subtypes"] = {}
all_printings["map_cards_supertypes"] = {}
all_printings["map_cards_types"] = []
all_printings["map_sets_cards"] = []
next_ruling_id = 0
freq = {}
types = {}
for set_code in list(all_printings["data"].keys()):
    # Remove Alchemy sets.
    if all_printings["data"][set_code]["name"].startswith("Alchemy"):
        all_printings["data"].pop(set_code, None)
        continue

    for field in all_printings["data"][set_code]:
        if field in freq:
            freq[field] += 1
        else:
            freq[field] = 1
        if not field in types:
            if type(all_printings["data"][set_code][field]) is list:
                types[field] = "list"
                #print(set_code, field)
                #for item in all_printings["data"][set_code][field][:min(len(all_printings["data"][set_code][field]), 10)]:
                    #print(f"\t{str(item)[:min(len(item), 100)]}")
            elif type(all_printings["data"][set_code][field]) is dict:
                types[field] = "dict"
            elif type(all_printings["data"][set_code][field]) is str:
                types[field] = "str"
            elif type(all_printings["data"][set_code][field]) is int:
                types[field] = "int"
            elif type(all_printings["data"][set_code][field]) is bool:
                types[field] = "bool"
            else:
                types[field] = "error"

    remove_cards = []
    for card in all_printings["data"][set_code]["cards"]:
        # Remove online only cards.
        if "isOnlineOnly" in card:
            remove_cards.append(card["uuid"])
            continue
        # Remove oversized cards.
        if "isOversized" in card:
            remove_cards.append(card["uuid"])
            continue
        # Remove Vanguards.
        if "originalType" in card and card["originalType"] in ("Vanguard", "Vanguard - Character",):
            remove_cards.append(card["uuid"])
            continue
        # Normalize promo_types and create map_cards_promo_types.
        if "promoTypes" in card:
            if "alchemy" in card["promoTypes"] or "rebalanced" in card["promoTypes"]:
                remove_cards.append(card["uuid"])
                continue
            for item in card["promoTypes"]:
                if not item in all_printings["promo_types"]:
                    all_printings["promo_types"].append(item)
                all_printings["map_cards_promo_types"][card["uuid"]] = item
        # Normalize artists.
        if "artist" in card:
            artist_names = card["artist"].split(" & ")
            if len(card["artistIds"]) == 1:
                if card["artist"] in all_printings["artists"] and all_printings["artists"][card["artist"]] != card["artistIds"][0]:
                    print(f"Overwriting artist {card['artist']}.")
                all_printings["artists"][card["artistIds"][0]] = artist_names[0] 
            elif len(card["artistIds"]) > 1:
                if len(artist_names) < 2 and "faceName" in card:
                    if card["name"].startswith(card["faceName"]):
                        all_printings["artists"][card["artistIds"][0]] = artist_names[0] 
                    else:
                        all_printings["artists"][card["artistIds"][1]] = artist_names[0] 
                elif len(artist_names) >= 2 and len(artist_names) == len(card["artistIds"]):
                    for ii in range(len(artist_names)):
                        all_printings["artists"][card["artistIds"][ii]] = artist_names[ii] 
        # Create map_cards_artists.
        if "artistIds" in card:
            for id in card["artistIds"]:
                all_printings["map_cards_artists"][card["uuid"]] = id
        # Create map_cards_attraction_lights.
        if "attractionLights" in card:
            for item in card["attractionLights"]:
                all_printings["map_cards_attraction_lights"][card["uuid"]] = item
        # Create map_cards_color_identity.
        for item in card["colorIdentity"]:
            all_printings["map_cards_color_identity"][card["uuid"]] = item
        # Create map_cards_color_indicators.
        if "colorIndicator" in card:
            for item in card["colorIndicator"]:
                all_printings["map_cards_color_indicators"][card["uuid"]] = item
        # Create map_cards_colors.
        for item in card["colors"]:
            all_printings["map_cards_colors"][card["uuid"]] = item
        # Normalize finishes and create map_cards_finishes.
        for item in card["finishes"]:
            if not item in all_printings["finishes"]:
                all_printings["finishes"].append(item)
            all_printings["map_cards_finishes"].append((card["uuid"], item,))
        # Normalize frame_effects and create map_cards_frame_effects.
        if "frameEffects" in card:
            for item in card["frameEffects"]:
                if not item in all_printings["frame_effects"]:
                    all_printings["frame_effects"].append(item)
                all_printings["map_cards_frame_effects"][card["uuid"]] = item
        # Normalize keywords and create map_cards_keywords.
        if "keywords" in card:
            for item in card["keywords"]:
                if not item in all_printings["keywords"]:
                    all_printings["keywords"].append(item)
                all_printings["map_cards_keywords"][card["uuid"]] = item
        # Create map_cards_other_face_ids.
        if "otherFaceIds" in card:
            for item in card["otherFaceIds"]:
                all_printings["map_cards_other_face_ids"].append((card["uuid"], item,))
        # Create map_sets_cards.
        all_printings["map_sets_cards"].append((set_code, card["uuid"],))
        # Normalize rulings and create map_cards_rulings.
        if "rulings" in card:
            for item in card["rulings"]:
                ruling_id = next_ruling_id
                find_index = -1
                try:
                    pass#find_index = list(all_printings["rulings"].values()).index(item)
                except Exception as e:
                    pass
                if find_index < 0:
                    all_printings["rulings"][next_ruling_id] = item
                    next_ruling_id += 1
                else:
                    ruling_id = find_index
                all_printings["map_cards_rulings"][card["uuid"]] = ruling_id
        # Normalize subsets and create map_cards_subsets.
        if "subsets" in card:
            for item in card["subsets"]:
                if not item in all_printings["subsets"]:
                    all_printings["subsets"].append(item)
                all_printings["map_cards_subsets"][card["uuid"]] = item
        # Normalize subtypes and create map_cards_subtypes.
        if "subtypes" in card:
            for item in card["subtypes"]:
                if not item in all_printings["subtypes"]:
                    all_printings["subtypes"].append(item)
                all_printings["map_cards_subtypes"][card["uuid"]] = item
        # Normalize supertypes and create map_cards_supertypes.
        if "supertypes" in card:
            for item in card["supertypes"]:
                if not item in all_printings["supertypes"]:
                    all_printings["supertypes"].append(item)
                all_printings["map_cards_supertypes"][card["uuid"]] = item
        # Normalize types and create map_cards_types.
        for item in card["types"]:
            if not item in all_printings["types"]:
                all_printings["types"].append(item)
            all_printings["map_cards_types"].append((card["uuid"], item,))
        # Create map_cards_sets_variations.
        if "variations" in card:
            for item in card["variations"]:
                all_printings["map_cards_sets_variations"].append({
                    "card_uuid": card["uuid"],
                    "set_code": set_code,
                    "variation_uuid": item,
                })
        # Add card.
        all_printings["cards"].append({
            "ascii_name" : card["asciiName"] if "asciiName" in card else None,
            "border_color" : card["borderColor"],
            "defense" : card["defense"] if "defense" in card else None,
            "edhrec_rank" : card["edhrecRank"] if "edhrecRank" in card else None,
            "edhrec_saltiness" : card["edhrecSaltiness"] if "edhrecSaltiness" in card else None,
            "face_flavor_name" : card["faceFlavorName"] if "faceFlavorName" in card else None,
            "face_mana_value" : card["faceManaValue"] if "faceManaValue" in card else None,
            "face_name" : card["faceName"] if "faceName" in card else None,
            "flavor_name" : card["flavorName"] if "flavorName" in card else None,
            "flavor_text" : card["flavorText"] if "flavorText" in card else None,
            "frame_version" : card["frameVersion"],
            "has_alternative_deck_limit" : card["hasAlternativeDeckLimit"] if "hasAlternativeDeckLimit" in card else False,
            "has_foil" : card["hasFoil"],
            "has_non_foil" : card["hasNonFoil"],
            "is_alternative" : card["isAlternative"] if "isAlternative" in card else False,
            "is_full_art" : card["isFullArt"] if "isFullArt" in card else False,
            "is_promo" : card["isPromo"] if "isPromo" in card else False,
            "is_reprint" : card["isReprint"] if "isReprint" in card else False,
            "is_reserved" : card["isReserved"] if "isReserved" in card else False,
            "is_story_spotlight" : card["isStorySpotlight"] if "isStorySpotlight" in card else False,
            "is_textless" : card["isTextless"] if "isTextless" in card else False,
            "is_timeshifted" : card["isTimeshifted"] if "isTimeshifted" in card else False,
            "language" : card["language"],
            "layout" : card["layout"],
            "loyalty" : card["loyalty"] if "loyalty" in card else None,
            "mana_cost" : card["manaCost"] if "manaCost" in card else None,
            "mana_value" : card["manaValue"],
            "name" : card["name"],
            "number" : card["number"],
            "original_release_date" : card["originalReleaseDate"] if "originalReleaseDate" in card else None,
            "original_text" : card["originalText"] if "originalText" in card else None,
            "original_type" : card["originalType"] if "originalType" in card else None,
            "power" : card["power"] if "power" in card else None,
            "rarity" : card["rarity"],
            "security_stamp" : card["securityStamp"] if "securityStamp" in card else None,
            "set_code" : card["setCode"],
            "side" : card["side"] if "side" in card else None,
            "signature" : card["signature"] if "signature" in card else None,
            "text" : card["text"] if "text" in card else None,
            "toughness" : card["toughness"] if "toughness" in card else None,
            "type" : card["type"],
            "uuid" : card["uuid"],
            "watermark" : card["watermark"] if "watermark" in card else None,
        })

    # Remove unused set data.
    all_printings["data"][set_code].pop("boosterTypes", None)
    all_printings["data"][set_code].pop("cardParts", None)
    all_printings["data"][set_code].pop("foreignData", None)
    all_printings["data"][set_code].pop("leadershipSkills", None)
    all_printings["data"][set_code].pop("purchaseUrls", None)
    all_printings["data"][set_code].pop("relatedCards", None)
    all_printings["data"][set_code].pop("rebalancedPrintings", None)
    all_printings["data"][set_code].pop("sourceProducts", None)
    all_printings["data"][set_code].pop("translations", None)

    all_printings["data"][set_code]["cards"] = [card for card in all_printings["data"][set_code]["cards"] if not card["uuid"] in remove_cards]

all_vals = []
for card in all_printings["cards"]:
    insert_vals = []
    for key, val in card.items():
        if isinstance(val, bool):
            insert_vals.append(str(val).lower())
        elif isinstance(val, str):
            clean_val = val.replace("\n", "\\n").replace("'", "''")
            insert_vals.append(f"'{clean_val}'")
        elif val == None:
            insert_vals.append("null")
        else:
            insert_vals.append(f"{val}")
    all_vals.append(f"({', '.join(insert_vals)})")
with open("dml.sql", "w") as fout:
    fout.write(f"insert into public.cards (ascii_name, border_color, defense, edhrec_rank, edhrec_saltiness, face_flavor_name, face_mana_value, face_name, flavor_name, flavor_text, frame_version, has_alternative_deck_limit, has_foil, has_non_foil, is_alternative, is_full_art, is_promo, is_reprint, is_reserved, is_story_spotlight, is_textless, is_timeshifted, language, layout, loyalty, mana_cost, mana_value, name, number, original_release_date, original_text, original_type, power, rarity, security_stamp, set_code, side, signature, text, toughness, type, uuid, watermark)\n")
    fout.write("values\n")
    all_vals_str = ',\n'.join(all_vals)
    fout.write(f"{all_vals_str};\n")


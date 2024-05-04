drop table if exists cards;

create table cards (
    ascii_name                  text,
    border_color                text not null,
    defense                     text,
    edhrec_rank                 int,
    edhrec_saltiness            real,
    face_flavor_name            text,
    face_mana_value             text,
    face_name                   text,
    flavor_name                 text,
    flavor_text                 text,
    frame_version               text not null,
    has_alternative_deck_limit  boolean not null,
    has_foil                    boolean not null,
    has_non_foil                boolean not null,
    is_alternative              boolean not null,
    is_full_art                 boolean not null,
    is_promo                    boolean not null,
    is_reprint                  boolean not null,
    is_reserved                 boolean not null,
    is_story_spotlight          boolean not null,
    is_textless                 boolean not null,
    is_timeshifted              boolean not null,
    language                    text not null,
    layout                      text not null,
    loyalty                     text,
    mana_cost                   text,
    mana_value                  real not null,
    name                        text not null,
    number                      text not null,
    original_release_date       text,
    original_text               text,
    original_type               text,
    power                       text,
    rarity                      text not null,
    scryfall_id                 uuid not null,
    security_stamp              text,
    set_code                    text not null,
    side                        text,
    signature                   text,
    text                        text,
    toughness                   text,
    type                        text not null,
    uuid                        uuid not null,
    watermark                   text,
    primary key (uuid)
);

create table artists (
);

create table finishes (
);

create table frame_effects (
);

create table keywords (
);

create table printing_groups (
    uuid                        uuid not null,
    default_card_uuid           uuid not null references cards(uuid),
    primary key (uuid)
);

create table promo_types (
);

create table rulings (
    uuid                        uuid not null,
    date                        date not null,
    text                        text not null,
    primary key (uuid)
);

create table subsets (
);

create table subtypes (
);

create table supertypes (
);

create table types (
);

create table map_cards_artists (
);

create table map_cards_attraction_lights (
);

create table map_cards_color_identity (
);

create table map_cards_color_indicators (
);

create table map_cards_colors (
);

create table map_cards_finishes (
);

create table map_cards_frame_effects (
);

create table map_cards_keywords (
);

create table map_cards_other_face_ids (
);

create table map_cards_promo_types (
);

create table map_cards_rulings (
    card_uuid                   uuid not null references cards(uuid),
    ruling_uuid                 uuid not null references rulings(uuid),
    primary key (card_uuid, ruling_uuid)
);

create table map_cards_sets_variations (
);

create table map_cards_subsets (
);

create table map_cards_subtypes (
);

create table map_cards_supertypes (
);

create table map_cards_types (
);

create table map_printing_groups_cards (
    printing_group_uuid         uuid not null references printing_groups(uuid),
    card_uuid                   uuid not null references cards(uuid),
    primary key (printing_group_uuid, card_uuid)
);

create table map_sets_cards (
);


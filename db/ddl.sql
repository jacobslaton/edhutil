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
    frame_version               text,
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

select * from lineitem
delete from lineitem
insert into lineitem(id) values(1)

-- SEQUENCE: public.li_base_id_seq

-- DROP SEQUENCE public.li_base_id_seq;

CREATE SEQUENCE public.li_base_id_seq;

ALTER SEQUENCE public.li_base_id_seq OWNER TO vidb;

GRANT SELECT ON SEQUENCE public.li_base_id_seq TO nagios;

GRANT ALL ON SEQUENCE public.li_base_id_seq TO vidb05_pms_admin;

GRANT ALL ON SEQUENCE public.li_base_id_seq TO vidb;

insert into lineitem values(1,2882,'753:6779',96772283,164445456,'2018-09-17','',719307,114811090,1,1,35,'desc','2018-09-17');
select * from campaign_targeting.get_active_patients(2882,'1 day','2018-09-17')
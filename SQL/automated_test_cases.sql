 select distinct l.hid, l.client_id, l.patient_id
                from  public.lineitem l
                where hid = 2882
                and   l.date >= '2018-09-17'::date - '10 days'::interval;
                
               select *
                from  public.lineitem l
                where hid = 2882